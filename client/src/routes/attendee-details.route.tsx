import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { PageWrapper } from "../presentation/components/page-wrapper.component";
import { AttendeeModel } from "../domain/models/attendee.model";
import { AttendeeType } from "../application/NewFolder1/attendee-type";
import { getAttendeeById } from "../application/use-cases/fetch-attendee-by-id.use-case";
import { AttendeeDetailsForm } from "../presentation/components/attendee-details.form";
import useForm from "../application/NewFolder/use-form.hook";
import { ActionGroup } from "../presentation/components/action-group.component";
import { getPaymentMethods } from "../application/use-cases/fetch-payment-methods.use-case";

export function AttendeeDetailsRoute() {

    const initialValues = {
        id: "",
        firstName: "",
       lastName: "",
        personalIdCode: "",
        paymentMethodId: "",
        additionalInfo: "",
        type: AttendeeType.NaturalPerson
    };
    const validators = {}
    const form = useForm(initialValues, validators);

    const { attendeeId } = useParams<{ attendeeId: string }>();
    const [attendee, setAttendee] = useState<AttendeeModel | null>(null);
    const [paymentMethods, setPaymentMethods] = useState([]);

    useEffect(() => {
        if (attendee) {
            console.log(attendee);
            form.setValues(attendee);
        }
    }, [attendee]);


    useEffect(() => {
        const fetchAttendee = async () => {
            if (attendeeId) {
                const fetchedAttendee = await getAttendeeById(attendeeId);
                setAttendee(fetchedAttendee);
            }
        };
        const fetchPaymentMethods = async () => {
            const paymentMethodsData = await getPaymentMethods();
            setPaymentMethods(paymentMethodsData);
        }
        fetchAttendee();
        fetchPaymentMethods();
    }, [attendeeId]);

    const postSubmit = () => {}

    const onSubmit = () => form.handleSubmit(postSubmit)

    return (
        <PageWrapper title="Attendee Details">
            {attendee ? (
                <div>
                <AttendeeDetailsForm {...form} paymentMethods={paymentMethods} />
                <ActionGroup actions={[{ title: "Tagasi", variant: 'secondary', onClick: () => { } }
                    , { title: "Lisa", variant: 'primary', onClick: onSubmit, isDisabled: !form.isValid }]} />
            </div>
            ) : (
                <p>Loading attendee details...</p>
            )}
        </PageWrapper>
    );
}
