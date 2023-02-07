import { Component, ElementRef, EventEmitter, HostListener, Input, Output } from '@angular/core';

@Component({
  selector: 'app-input-box',
  templateUrl: './input-box.component.html',
  styleUrls: ['./input-box.component.css']
})
export class InputBoxComponent {
  @Input()
  value :string;

  @Output() valueChange = new EventEmitter<string>()
  private operators = '+-*/'

  constructor(private el: ElementRef){
    this.value = ''
  }

  @HostListener('keypress', ['$event']) onKeyPress(event: KeyboardEvent){
    const char = String.fromCharCode(event.charCode);
    if (!this.isValid(char)){
      event.preventDefault();
    }
  }

  onInput(){
    this.valueChange.emit(this.value);
  }

  isValid(char: string): boolean | RegExpMatchArray {
    return char.match(/\d/) || this.operators.indexOf(char) >= 0;
  }
}
