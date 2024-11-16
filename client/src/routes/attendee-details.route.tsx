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

export function AttendeeDetailsRoute() {
    const navigate = useNavigate();
    const [initialValues, setInitialValues] = useState({
        firstName: "",
       lastName: "",
        personalIdCode: "",
        paymentMethodId: "",
        additionalInfo: "",
        type: AttendeeType.NaturalPerson
    });
    const validators = {}
    const form = useForm(initialValues, validators);

    const { attendeeId } = useParams<{ attendeeId: string }>();
    const [attendee, setAttendee] = useState<AttendeeModel | null>(null);
    const [paymentMethods, setPaymentMethods] = useState([]);
    const [isSubmitting, setIsSubmitting] = useState(false);


    useEffect(() => {
        const fetchAttendee = async () => {
            if (attendeeId) {
                const fetchedAttendee = await getAttendeeById(attendeeId);
                setAttendee(fetchedAttendee);
                const mappedAttendee = {
                    firstName: fetchedAttendee.firstName || "",
                    lastName: fetchedAttendee.lastName || "",
                    personalIdCode: fetchedAttendee.personalIdCode || "",
                    paymentMethodId: fetchedAttendee.paymentMethodId || "",
                    legalName: fetchedAttendee.legalName || "",
                    companyRegistrationCode: fetchedAttendee.companyRegistrationCode || "",
                    attendeeCount: fetchedAttendee.attendeeCount || null,
                    additionalInfo:fetchedAttendee.additionalInfo || "",
                    type: fetchedAttendee.type || AttendeeType.NaturalPerson, 
    
                };
                setInitialValues(mappedAttendee);
                form.handleSetValues(mappedAttendee);
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
            {attendee ? (
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
