import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class Home {
    id: number = 1;
    name: string = 'Md Shahjahan';
    familyName: string = 'Miahhhh';
    address: string = 'Bangkok,Thailand';
    countryOfOrigin: string = 'Bangladesh';
    emailAddress: string = 'blackbee08@gmail.com';
    age: number = 33;
    hired: boolean = true;


    SaveApplicant(http: HttpClient) {
        var payload = {
            id: this.id,
            name: this.name,
            familyName: this.familyName,
            address: this.address,
            countryOfOrigin: this.countryOfOrigin,
            emailAddress: this.emailAddress,
            age: this.age,
            hired: this.hired
        }

        http.fetch('http://localhost:51526/api/Applicant', {
            method: "POST",
            body: JSON.stringify(payload)
        }).then(response => response.json()).then(data => {
            console.log(data);
            alert('Hasan');
        });
    }
}
