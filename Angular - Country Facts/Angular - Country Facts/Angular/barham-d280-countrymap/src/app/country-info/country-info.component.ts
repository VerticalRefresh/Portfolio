import { Component, Input } from '@angular/core';
import { countryInfo } from './country-info';
import { WorldBankCallerService } from '../world-bank-caller.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-country-info',
  standalone: true,
  imports: [],
  templateUrl: './country-info.component.html',
  styleUrl: './country-info.component.css'
})

export class CountryInfoComponent {

  constructor (private apiService: WorldBankCallerService) {}

  //Data from map component mouseover
  @Input() countryCode: string = '';


  //Data from home component http processing
  @Input() countryInfo: countryInfo = {id: '',
    name: '',
    capital: '',
    region: '',
    incomeLevel: '',
    latitude: '',
    longitude: ''
  };
}

