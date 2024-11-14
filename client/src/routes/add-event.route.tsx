import { AddEventForm } from "../presentation/components/add-event.form";
import { Button } from "../presentation/components/button.component";
import { PageWrapper } from "../presentation/components/page-wrapper.component";
import { createEvent } from "../application/use-cases/create-event.use-case";
import useForm from "../application/NewFolder/use-form.hook";
import { required } from "../application/NewFolder/validators";
import { ActionGroup } from "../presentation/components/action-group.component";

export function AddEventRoute()
{
    const initialValues = {
        name: "",
        date: "",
        location: "",
        additionalInfo: ""

    }

    const validators = {
        name: required,
        date: required,
        location: required,
        additionalInfo: required
    };


    const { isValid, values, errors, handleChange, handleBlur, handleSubmit } = useForm(initialValues, validators);

    const postSubmit = async (data: any) => {
        console.log(data)
        const res = await createEvent(data);

        console.log("Event created -", res);
    }

    const onSubmit = handleSubmit(postSubmit)


    return <PageWrapper title="Ürituse lisamine">
        <div className="flex flex-col p-8">
            <AddEventForm values={values} errors={errors} handleChange={handleChange} handleBlur={handleBlur} />
            <div className="mt-8">
                <ActionGroup actions={[
                    { title: 'Tagasi', variant: 'secondary', onClick: () => { } },
                    { title: 'Lisa', variant: 'primary', onClick: onSubmit, isDisabled: !isValid }
                ] } />
            </div>
        
        </div>
    </PageWrapper>
}