import { useNavigate, useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { PageWrapper } from "../presentation/components/page-wrapper.component";
import { AttendeeModel } from "../domain/models/attendee.model";
import { AttendeeType } from "../application/types/attendee-type";
import { getAttendeeById } from "../application/use-cases/fetch-attendee-by-id.use-case";
import { AttendeeDetailsForm } from "../presentation/components/attendee-details.form";
import useForm from "../application/hooks/use-form.hook";
import { ActionGroup } from "../presentation/components/action-group.component";
import { getPaymentMethods } from "../application/use-cases/fetch-payment-methods.use-case";
import { updateAttendee } from "../application/use-cases/update-attendee.use-case";
import { required, validateEstonianIdCode } from "../application/hooks/validators";

export function AttendeeDetailsRoute() {
    const navigate = useNavigate();
    
    const [initialValues, setInitialValues] = useState({});

    const naturalPersonValidators = {
        firstName: required,
        lastName: required,
        personalIdCode: (val: string) =>{ return required(val) || validateEstonianIdCode(val) },
    }

    const legalEntityValidators = {
        legalName: required,
        companyRegistrationCode: required,
    }
    const form = useForm(initialValues, {});

    const { attendeeId } = useParams<{ attendeeId: string }>();
    const [attendee, setAttendee] = useState<AttendeeModel | null>(null);
    const [paymentMethods, setPaymentMethods] = useState([]);
    const [isSubmitting, setIsSubmitting] = useState(false);

    useEffect(() => {
        console.log(form.errors)
        console.log(form.isValid)
        console.log(isSubmitting)
    }, [form]);


    useEffect(() => {
        const fetchAttendee = async () => {
            if (attendeeId) {
                const fetchedAttendee = await getAttendeeById(attendeeId);
                setAttendee(fetchedAttendee);
                console.log(fetchedAttendee)
                if(fetchedAttendee?.type === AttendeeType.NaturalPerson) {
                    const mappedAttendee = {
                        firstName: fetchedAttendee.firstName || "",
                        lastName: fetchedAttendee.lastName || "",
                        personalIdCode: fetchedAttendee.personalIdCode || "",
                        paymentMethodId: fetchedAttendee.paymentMethodId || "",
                        additionalInfo: fetchedAttendee.additionalInfo || "",
                        type: AttendeeType.NaturalPerson,
                    }
                    setInitialValues(mappedAttendee);
                    form.setValidators(naturalPersonValidators);
                    form.handleSetValues(mappedAttendee);
                } else {
                    const mappedAttendee = {
                        legalName: fetchedAttendee.legalName || "",
                        companyRegistrationCode: fetchedAttendee.companyRegistrationCode || "",
                        paymentMethodId: fetchedAttendee.paymentMethodId || "",
                        attendeeCount: fetchedAttendee.attendeeCount || null,
                        additionalInfo: fetchedAttendee.additionalInfo || "",
                        type: AttendeeType.LegalEntity,
                    }
                    form.setValidators(legalEntityValidators);
                    setInitialValues(mappedAttendee);
                form.handleSetValues(mappedAttendee);

                }
            
                
            }
        };
        const fetchPaymentMethods = async () => {
            const paymentMethodsData = await getPaymentMethods();
            setPaymentMethods(paymentMethodsData);
        }
        fetchAttendee();
        fetchPaymentMethods();
    }, [attendeeId]);

    const postSubmit = async (data: AttendeeModel) => {
        setIsSubmitting(true);
        await updateAttendee(attendeeId!, data);
        setIsSubmitting(false);
    }   

    const onSubmit = form.handleSubmit(postSubmit, false);

    return (
        <PageWrapper title="Osaleja">
            {attendee && attendee?.type ? (
                <div>
                <AttendeeDetailsForm {...form} paymentMethods={paymentMethods} />
                <ActionGroup actions={[{ title: "Tagasi", variant: 'secondary', onClick: () => navigate(-1) }
                    , { title: "Salvesta", variant: 'primary', onClick: () => onSubmit(), isDisabled: !form.isValid || isSubmitting }]} />
            </div>
            ) : (
                <p>Loading attendee details...</p>
            )}
        </PageWrapper>
    );
}
