import { AttendeeType } from "../../application/types/attendee-type";
import { AttendeeModel } from "../../domain/models/attendee.model";
import { PaymentMethodModel } from "../../domain/models/payment-method.model";
import { mapPaymentMethodOptions } from "../helpers/map-payment-methods.helper";
import { FormField } from "./form-field.component";

export function AttendeeDetailsForm({
    values,
    errors,
    handleChange,
    handleBlur,
    paymentMethods
}: {
    values: Record<keyof AttendeeModel, string>;
    errors: Record<string, string>;
    handleChange: (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => void;
    handleBlur: (e: React.FocusEvent<HTMLInputElement | HTMLTextAreaElement>) => void;
    paymentMethods: PaymentMethodModel[]
}) {
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
        name: 'paymentMethodId', label: "Maksemeetod", type: "select", options: mapPaymentMethodOptions(paymentMethods)
        }, {
            name: "companyRegistrationCode", label: "Registrikood"
        },
        {
            name: "attendeeCount", type: "number", label: "Osalejate arv"
        },
        {
            name: "additionalInfo", label: "Lisainfo", type:
                "textarea"
        }

    ]

    console.log(values.type)

    return (
        <form className="flex flex-col gap-4 w-full max-w-lg">
            {(values.type === AttendeeType.NaturalPerson ? naturalPersonFields : legalEntityFields).map((field, idx) => {
            return <FormField key={ "attendee-form-" + idx} type={field.type} options={ field.options } label={field.label} name={field.name} value={values[field.name as keyof AttendeeModel]} onChange={handleChange} onBlur={handleBlur} error={errors[field.name]} />
        }) }
        </form>
    );
}
