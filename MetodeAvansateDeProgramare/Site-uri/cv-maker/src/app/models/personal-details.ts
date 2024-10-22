export class PersonalDetails {
    name: string;
    jobTitle: string;
    email: string;
    phoneNumber: string;
    address: string;

    constructor(name: string, jobTitle: string, email: string,
        phoneNumber: string, address: string
    ) {
        this.name = name;
        this.jobTitle = jobTitle;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.address = address;
    }
} 