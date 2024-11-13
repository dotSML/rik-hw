

export class AttendeeModel  {
    public id: string;
    public name: string;
    public personalCode?: string;
    public companyRegistryCode?: string;
    constructor({ id, name, personalCode, companyRegistryCode }: {id: string, name: string, personalCode?: string, companyRegistryCode?: string}) {
        this.id = id;
        this.name = name;
        this.personalCode = personalCode;
        this.companyRegistryCode = companyRegistryCode;
    }

}