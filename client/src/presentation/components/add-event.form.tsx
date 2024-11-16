import { FormField } from "./form-field.component";

export function AddEventForm({ values, errors, handleChange, handleBlur }: { values: Record<string, string>, errors: Record<string, string>, handleChange: (e: Event) => void, handleBlur: (e: Event) => void; }) {

    return <form>
        <FormField name="name" label="Ürituse nimi" value={values.name} onChange={handleChange} onBlur={handleBlur} error={errors.name } />
        <FormField type="date" name="date" label="Toimumise aeg" value={values.date} onChange={handleChange} onBlur={handleBlur} error={errors.date} />
        <FormField name="location" label="Koht" value={values.location} onChange={handleChange} onBlur={handleBlur} error={errors.location} />
        <FormField type="textarea" name="additionalInfo" label="Lisainfo: " value={values.additionalInfo} onChange={handleChange} onBlur={handleBlur} error={errors.additionalInfo} />
    </form>
}