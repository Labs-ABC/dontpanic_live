import { Component, ElementRef, Input } from '@angular/core';

@Component({
  selector: 'app-input-box-block',
  templateUrl: './input-box-block.component.html',
  styleUrls: ['./input-box-block.component.css']
})
export class InputBoxBlockComponent {
  @Input()
  value :string;

  @Input()
  inputClass = "input";

  constructor(private el: ElementRef){
    this.value = ''
  }


}
