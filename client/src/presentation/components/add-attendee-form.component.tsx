import { FormField } from "./form-field.component";
import RadioField from "./radio-field.component";
import { PaymentMethodModel } from "../../domain/models/payment-method.model";
import { AttendeeType } from "../../application/types/attendee-type";
import { mapPaymentMethodOptions } from "../helpers/map-payment-methods.helper";
import { ChangeEvent } from "react";

export function AddAttendeeForm({ paymentMethods, values, errors, handleChange, handleBlur, handleSetValues }: { handleSetValues: (data: Record<string, string>) => void; paymentMethods: PaymentMethodModel[], values: Record<string, string>, errors: Record<string, string>, handleChange: (e: ChangeEvent<HTMLInputElement>) => void, handleBlur: (e: React.FocusEvent<HTMLInputElement | HTMLTextAreaElement>) => void }) {
    const naturalPersonFields = [{
        name: 'firstName', label: "Eesnimi"
    }, { name: 'lastName', label: "Perekonnanimi" }, { name: 'personalIdCode', label: "Isikukood" }, {
        name: "paymentMethodId", label: "Maksemeetod", type: "select", options: mapPaymentMethodOptions(paymentMethods)

    }, {
        name: "additionalInfo", label: "Lisainfo", type:
            "textarea"
        }];


    const legalEntityFields = [{
        name: "legalName", label: "Ettevõtte nimi",

    }, {
        name: "paymentMethodId", label: "Maksemeetod", type: "select", options: mapPaymentMethodOptions(paymentMethods)
        }, {
            name: "companyRegistrationCode", label: "Registrikood"
        },
        {
            name: "attendeeCount", label: "Osalejate arv", min: 1, type: "number"
        },
        {
            name: "participantRequests", label: "Osalejate soovid", type: "textarea"
        },
        {
            name: "additionalInfo", label: "Lisainfo", type:
                "textarea"
        },

    ]

    return <form>
            <div className="grid grid-cols-3 gap-4">
            <div></div>
            <RadioField name="type" className="col-span-2 gap-16 py-4" options={[{ label: "Eraisik", value: "NaturalPerson" }, { label: "Ettevõte", value: "LegalEntity" }]} selectedValue={values.type} onChange={(val) => handleSetValues({type: val})} />

            </div>


        {(values.type === AttendeeType.NaturalPerson ? naturalPersonFields : legalEntityFields).map((field, idx) => {
            return <FormField min={field.min} key={ "attendee-form-" + idx} type={field.type} options={ field.options } label={field.label} name={field.name} value={values[field.name]} onChange={handleChange} onBlur={handleBlur} error={errors[field.name]} />})}
    </form>
}