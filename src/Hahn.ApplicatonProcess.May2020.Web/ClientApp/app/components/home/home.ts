import { HttpClient, json } from 'aurelia-fetch-client';

let httpClient = new HttpClient();
export class Home {

    id: number = 1;
    name: string = 'Md Shahjahan';
    familyName: string = 'Miahhhh';
    address: string = 'Bangkok,Thailand';
    countryOfOrigin: string = 'Bangladesh';
    emailAddress: string = 'blackbee08@gmail.com';
    age: number = 33;
    hired: boolean = true;


    SaveApplicant() {
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
        const baseUrl = 'http://localhost:51526/api/';
        httpClient.baseUrl = baseUrl;

        return httpClient.fetch('Applicant', {
            method: 'Post',
            mode: 'no-cors',
            body: JSON.stringify(payload),
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        })
            .then(response => response.json())
            .then(createdApplicant => {
                return createdApplicant;
            })
            .catch(error => {
                console.log('Error adding applicant.');
            });
    }
}
