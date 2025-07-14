import { Component, Input } from '@angular/core';
import { MapComponent } from "../map/map.component";
import { CountryInfoComponent } from "../country-info/country-info.component";
import { WorldBankCallerService } from '../world-bank-caller.service';
import { countryInfo } from '../country-info/country-info';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MapComponent, CountryInfoComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})

export class HomeComponent {

  countryCode: string = ''
  //Initializes countryInfo to be sent to component for display, so that nothing is displayed on load
  public countryInfo: countryInfo = {id: '',
    name: '',
    capital: '',
    region: '',
    incomeLevel: '',
    latitude: '',
    longitude: ''
  };

  constructor(private apiService: WorldBankCallerService) {}

  //Updates countryData object for use in HTML data binding
  updateData(event: any): void {
    this.countryCode = event.id;
    if (event instanceof SVGPathElement) {
      this.apiService.getApiData(this.countryCode).subscribe(data => {
        const countryData = data[1][0]
        this.countryInfo = {
          id: this.countryCode,
          name: countryData.name,
          capital: countryData.capitalCity,
          region: countryData.region.value,
          incomeLevel: countryData.incomeLevel.value,
          latitude: countryData.latitude,
          longitude: countryData.longitude
        };
      })
    };
  }
}
