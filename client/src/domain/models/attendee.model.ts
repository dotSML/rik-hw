import { AttendeeType } from "../../application/types/attendee-type";


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
    public eventId?: string;
    public type: AttendeeType;
    constructor({ id, eventId, paymentMethodId, type, additionalInfo, participantRequests, attendeeCount, legalName, firstName, lastName, personalIdCode, companyRegistrationCode }: { id: string, type: AttendeeType, firstName?: string, lastName?: string, personalIdCode?: string, companyRegistryCode?: string, legalName?: string, participantRequests?: string, additionalInfo?: string, attendeeCount?: number, companyRegistrationCode?: string, paymentMethodId?: string, eventId: string; }) {
        this.id = id;
        this.eventId = eventId;
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

    public static toPlain(attendee: AttendeeModel) {
        return {
            firstName: attendee.firstName,
            lastName: attendee.lastName,
            legalName: attendee.legalName,
            companyRegistrationCode: attendee.companyRegistrationCode,
            additionalInfo: attendee.additionalInfo,
            participantRequests: attendee.participantRequests,
            attendeeCount: attendee.attendeeCount,
            personalIdCode: attendee.personalIdCode,
            paymentMethodId: attendee.paymentMethodId,
            eventId: attendee.eventId,
            type: attendee.type
        }
    }

}