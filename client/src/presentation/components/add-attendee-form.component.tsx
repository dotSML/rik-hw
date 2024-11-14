import { useState } from "react";
import { FormField } from "./form-field.component";
import RadioField from "./radio-field.component";

export function AddAttendeeForm({ paymentMethods, values, errors, handleChange, handleBlur }: { values: Record<string, string>, errors: Record<string, string>, handleChange: (e: Event) => void, handleBlur: (e: Event) => void; }) {
    const [attendeeType, setAttendeeType] = useState('NaturalPerson');
    console.log("PM - ", paymentMethods)
    const naturalPersonFields = [{
        name: 'firstName', label: "Eesnimi"
    }, { name: 'lastName', label: "Perekonnanimi" }, { name: 'personalCode', label: "Isikukood" }, {
        name: "paymentMethod", label: "Maksemeetod", type: "select", 

    }, {
        name: "additionalInfo", label: "Lisainfo", type:
            "textarea"
        }];


    const legalEntityFields = [{
        name: "legalName", label: "Ettevõtte nimi",

    }, {
        name: 'paymentMethod', label: "Maksemeetod", type: "select"
        }, {
            name: "companyRegistryCode", label: "Registrikood"
        },
        {
            name: "attendeeCount", label: "Osalejate arv"
        },
        {
            name: "additionalInfo", label: "Lisainfo", type:
                "textarea"
        }

    ]

    return <form>
            <div className="grid grid-cols-3 gap-4">
            <div></div>
                <RadioField className="col-span-2 gap-16 py-4" options={[{ label: "Eraisik", value: "NaturalPerson" }, { label: "Ettevõte", value: "LegalEntity" }]} selectedValue={attendeeType} onChange={setAttendeeType} />

            </div>


        {(attendeeType === 'NaturalPerson' ? naturalPersonFields : legalEntityFields).map((field) => {
            return <FormField label={field.label} name={field.name} value={values[name]} onChange={handleChange} onBlur={handleBlur} errors={errors[name]} />
        }) }
    </form>
}