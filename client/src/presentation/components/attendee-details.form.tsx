import { AttendeeType } from "../../application/NewFolder1/attendee-type";
import { AttendeeModel } from "../../domain/models/attendee.model";
import { PaymentMethodModel } from "../../domain/models/payment-method.model";
import { FormField } from "./form-field.component";

export function AttendeeDetailsForm({
    values,
    errors,
    handleChange,
    handleBlur,
    paymentMethods
}: {
    values: Partial<AttendeeModel>;
    errors: Record<string, string>;
    handleChange: (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => void;
    handleBlur: (e: React.FocusEvent<HTMLInputElement | HTMLTextAreaElement>) => void;
    paymentMethods: PaymentMethodModel[]
}) {
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

    return (
        <form className="flex flex-col gap-4 w-full max-w-lg">
            {(values.type === AttendeeType.NaturalPerson ? naturalPersonFields : legalEntityFields).map((field, idx) => {
            return <FormField key={ "attendee-form-" + idx} type={field.type} options={ field.options } label={field.label} name={field.name} value={values[name]} onChange={handleChange} onBlur={handleBlur} error={errors[name]} />
        }) }
        </form>
    );
}
