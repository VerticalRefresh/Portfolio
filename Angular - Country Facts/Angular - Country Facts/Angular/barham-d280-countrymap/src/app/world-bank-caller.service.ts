import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class WorldBankCallerService {

  constructor(private http: HttpClient) { }
  
  
  //returns API data as observable JSON for parsing into individual fact components
  public getApiData(countryID: string): Observable<any> {
    return this.http.get(`https://api.worldbank.org/v2/country/${countryID}?format=json`);
  }
}
