import { Component, EventEmitter, HostListener, Input, Output } from '@angular/core';

@Component({
  selector: 'app-input-box',
  templateUrl: './input-box.component.html',
  styleUrls: ['./input-box.component.css']
})
export class InputBoxComponent {
  @Input()
  value :string;

  @Input()
  inputClass = "input";

  @Output()
  valueChange = new EventEmitter<string>()

  moveFocus(input: HTMLInputElement) {
    if (input.value.length === 1) {
      const nextInputId = Number(input.parentElement?.id) + 1;
      const nextInput = window.document.getElementById(nextInputId.toString());
      if (nextInput) {
        nextInput.querySelector('input')?.focus();
      }
    }
  }

  handleBackspace(event: KeyboardEvent, input: HTMLInputElement) {
    if (event.key == 'Backspace') {
      if (input.value.length === 1) {
        this.value = '';
        return;
      }
      const previousInputId = Number(input.parentElement?.id) - 1;
      const previousInput = window.document.getElementById(previousInputId.toString());
      if (previousInput) {
        const childInput = previousInput.querySelector('input');
        if (childInput) {
          childInput.focus();
          childInput.value = '';
        }
      }
    }
  }

  private operators = '+-*/'

  constructor() {
    this.value = '';
  }

  @HostListener('keypress', ['$event']) onKeyPress(event: KeyboardEvent){
    const char = String.fromCharCode(event.keyCode);
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
