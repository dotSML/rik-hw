

export class AttendeeModel  {
    public id: string;
    
    public firstName?: string;
    public lastName?: string;
    public legalName?: string;
    public companyRegistrationCode?: string;
    public additionalInfo?: string;
    public participantRequests?: string;
    public attendeeCount?: number;
    public personalIdCode?: string;
    public paymentMethodId?: string;
    public type: "NaturalPerson" | "LegalEntity"
    constructor({ id, paymentMethodId, type, additionalInfo, participantRequests, attendeeCount, legalName, firstName, lastName, personalIdCode, companyRegistrationCode }: { id: string, type: "NaturalPerson" | "LegalEntity", firstName?: string, lastName?: string, personalIdCode?: string, companyRegistryCode?: string, legalName?: string, participantRequests?: string, additionalInfo?: string, attendeeCount?: number, companyRegistrationCode?: string, paymentMethodId?: string }) {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.legalName = legalName;
        this.additionalInfo = additionalInfo;
        this.participantRequests = participantRequests;
        this.attendeeCount = attendeeCount;
        this.personalIdCode = personalIdCode;
        this.companyRegistrationCode = companyRegistrationCode;
        this.type = type;
        this.paymentMethodId = paymentMethodId;
    }

}