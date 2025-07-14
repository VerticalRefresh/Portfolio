import { Component, EventEmitter, Output} from '@angular/core';
import { WorldBankCallerService } from '../world-bank-caller.service';

@Component({
  selector: 'app-map',
  standalone: true,
  imports: [],
  templateUrl: './map.component.html',
  styleUrl: './map.component.css'
})
export class MapComponent{

  @Output() mouseOverEvent = new EventEmitter<any>();

  //Emits path to home component for http processing
  
  onMouseOver(event: MouseEvent) {
    let path = (event.target) as SVGPathElement;
    if (event.target instanceof SVGPathElement) {
      this.mouseOverEvent.emit(path);
    }
  }
}

