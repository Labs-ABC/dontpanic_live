import { Component } from '@angular/core';

@Component({
  selector: 'app-input-form',
  templateUrl: './input-form.component.html',
  styleUrls: ['./input-form.component.css']
})
export class InputFormComponent {
  equationInput: any ={
    firstInput: '',
    secondInput: '',
    thirdInput: '',
    fourthInput: '',
    fifthInput: '',
    sixthInput: '',
  }

  handleEquationSubmit(){
    console.log(this.equationInput);
  }
}

