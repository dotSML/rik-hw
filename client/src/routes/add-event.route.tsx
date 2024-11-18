import { AddEventForm } from '../presentation/components/add-event.form';
import { PageWrapper } from '../presentation/components/page-wrapper.component';
import { createEvent } from '../application/use-cases/create-event.use-case';
import useForm from '../application/hooks/use-form.hook';
import { dateInFuture, required } from '../application/hooks/validators';
import { ActionGroup } from '../presentation/components/action-group.component';
import { useNavigate } from 'react-router-dom';

export function AddEventRoute() {
  const navigate = useNavigate();
  const initialValues = {
    name: '',
    date: '',
    location: '',
    additionalInfo: '',
  };

  const validators = {
    name: required,
    date: (value: string) => {
      return required(value) || dateInFuture(value);
    },
    location: required,
  };

  const { isValid, values, errors, handleChange, handleBlur, handleSubmit } =
    useForm(initialValues, validators);

  const postSubmit = async (data: any) => {
    await createEvent(data);
    navigate('/');
  };

  const onSubmit = handleSubmit(postSubmit);

  return (
    <PageWrapper title="Ürituse lisamine">
      <div className="flex flex-col p-8">
        <h3 className="text-primaryBlue text-2xl mb-8">Ürituse lisamine</h3>
        <AddEventForm
          values={values}
          errors={errors}
          handleChange={handleChange}
          handleBlur={handleBlur}
        />
        <div className="mt-8">
          <ActionGroup
            actions={[
              { title: 'Tagasi', variant: 'secondary', onClick: () => {} },
              {
                title: 'Lisa',
                variant: 'primary',
                onClick: onSubmit,
                isDisabled: !isValid,
              },
            ]}
          />
        </div>
      </div>
    </PageWrapper>
  );
}
