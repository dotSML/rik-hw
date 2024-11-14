import { useState } from "react";
import { FormField } from "./form-field.component";
import RadioField from "./radio-field.component";
import { PaymentMethodModel } from "../../domain/models/payment-method.model";
import { AttendeeType } from "../../application/NewFolder1/attendee-type";

export function AddAttendeeForm({ paymentMethods, values, errors, handleChange, handleBlur }: { paymentMethods: PaymentMethodModel[], values: Record<string, string>, errors: Record<string, string>, handleChange: (e: Event) => void, handleBlur: (e: Event) => void; }) {
    const [attendeeType, setAttendeeType] = useState(AttendeeType.NaturalPerson);
    const naturalPersonFields = [{
        name: 'firstName', label: "Eesnimi"
    }, { name: 'lastName', label: "Perekonnanimi" }, { name: 'personalIdCode', label: "Isikukood" }, {
        name: "paymentMethodId", label: "Maksemeetod", type: "select", options: [{label: "", value: ""}, ...paymentMethods.map((pm) => ({ label: pm.method, value: pm.id }))]

    }, {
        name: "additionalInfo", label: "Lisainfo", type:
            "textarea"
        }];


    const legalEntityFields = [{
        name: "legalName", label: "Ettevõtte nimi",

    }, {
        name: 'paymentMethod', label: "Maksemeetod", type: "select"
        }, {
            name: "companyRegistrationCode", label: "Registrikood"
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
            <RadioField name="type" className="col-span-2 gap-16 py-4" options={[{ label: "Eraisik", value: "NaturalPerson" }, { label: "Ettevõte", value: "LegalEntity" }]} selectedValue={attendeeType} onChange={handleChange} />

            </div>


        {(attendeeType === AttendeeType.NaturalPerson ? naturalPersonFields : legalEntityFields).map((field, idx) => {
            return <FormField key={ "attendee-form-" + idx} type={field.type} options={ field.options } label={field.label} name={field.name} value={values[name]} onChange={handleChange} onBlur={handleBlur} error={errors[name]} />
        }) }
    </form>
}