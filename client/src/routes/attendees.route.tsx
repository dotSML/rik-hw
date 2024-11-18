import { useParams } from 'react-router-dom';
import { EventDetails } from '../presentation/components/event.component';
import { PageWrapper } from '../presentation/components/page-wrapper.component';
import { useState, useEffect } from 'react';
import { getEvent } from '../application/use-cases/fetch-event.use-case';
import { EventModel } from '../domain/models/event.model';
import { AttendeeModel } from '../domain/models/attendee.model';
import { fetchEventAttendees } from '../infrastructure/api/attendee.api';
import { AddAttendeeForm } from '../presentation/components/add-attendee-form.component';
import useForm from '../application/hooks/use-form.hook';
import { ActionGroup } from '../presentation/components/action-group.component';
import { createAttendee } from '../application/use-cases/create-attendee.use-case';
import { PaymentMethodModel } from '../domain/models/payment-method.model';
import { getPaymentMethods } from '../application/use-cases/fetch-payment-methods.use-case';
import { AttendeeType } from '../application/types/attendee-type';
import {
  isNumber,
  required,
  validateEstonianIdCode,
} from '../application/hooks/validators';

export function AttendeesRoute() {
  const { eventId } = useParams();
  const [isCreateAttendeeLoading, setIsCreateAttendeeLoading] = useState(false);

  const initialValues = {
    firstName: '',
    lastName: '',
    personalIdCode: '',
    paymentMethodId: '',
    additionalInfo: '',
    type: AttendeeType.NaturalPerson,
    participantRequests: '',
    attendeeCount: undefined,
    legalName: '',
    companyRegistrationCode: '',
    eventId,
  };

  const naturalPersonValidators = {
    firstName: required,
    lastName: required,
    personalIdCode: (value: string) => {
      return required(value) || validateEstonianIdCode(value);
    },
  };
  const legalEntityValidators = {
    legalName: required,
    companyRegistrationCode: required,
    attendeeCount: (val: string) => {
      return required(val) || isNumber(val);
    },
  };
  const form = useForm(
    initialValues,
    initialValues.type === AttendeeType.NaturalPerson
      ? naturalPersonValidators
      : legalEntityValidators
  );

  const [eventDetails, setEventDetails] = useState<EventModel>();
  const [attendees, setAttendees] = useState<AttendeeModel[]>([]);
  const [paymentMethods, setPaymentMethods] = useState<PaymentMethodModel[]>(
    []
  );

  useEffect(() => {
    const fetchEventDetailsData = async () => {
      if (eventId) {
        const eventDetailsData = await getEvent(eventId);
        setEventDetails(eventDetailsData);
      }
    };

    const fetchAttendees = async () => {
      if (eventId) {
        const attendeesData = await fetchEventAttendees(eventId);
        setAttendees(attendeesData);
      }
    };

    const fetchPaymentMethods = async () => {
      const paymentMethodsData = await getPaymentMethods();
      setPaymentMethods(paymentMethodsData);
    };

    fetchPaymentMethods();
    fetchEventDetailsData();
    fetchAttendees();
  }, [eventId]);

  useEffect(() => {
    const type = form.values.type;
    const newValidators =
      type === AttendeeType.NaturalPerson
        ? naturalPersonValidators
        : legalEntityValidators;
    form.setValidators(newValidators);
  }, [form.values.type]);

  const postSubmit = async (data: AttendeeModel) => {
    data.eventId = eventId;
    data.attendeeCount = data.attendeeCount
      ? Number(data.attendeeCount)
      : undefined;
    setIsCreateAttendeeLoading(true);
    const id = await createAttendee(data);
    data.id = id;

    setIsCreateAttendeeLoading(false);
    setAttendees((prev) => [...prev, data]);
  };

  const onSubmit = form.handleSubmit(postSubmit);

  return (
    <PageWrapper title="Osavõtjad">
      <div className="flex flex-col w-full gap-12 pb-32">
        <div className="max-w-[50%]">
          <h3 className="text-primaryBlue text-2xl mb-8">Osavõtjad</h3>
          {eventDetails?.name ? (
            <EventDetails
              eventData={eventDetails}
              attendees={attendees}
              handleSetAttendees={setAttendees}
            />
          ) : (
            ''
          )}
        </div>
        <div className="w-[50%]">
          <h3 className="text-primaryBlue text-2xl mb-8">
            Osavõtjate lisamine
          </h3>
          <AddAttendeeForm {...form} paymentMethods={paymentMethods} />
          <ActionGroup
            actions={[
              { title: 'Tagasi', variant: 'secondary', onClick: () => {} },
              {
                title: 'Lisa',
                variant: 'primary',
                onClick: onSubmit,
                isDisabled: !form.isValid || isCreateAttendeeLoading,
              },
            ]}
          />
        </div>
      </div>
    </PageWrapper>
  );
}
