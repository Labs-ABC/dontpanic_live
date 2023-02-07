import { Component } from '@angular/core';
import EquationInput from 'src/app/interfaces/EquationInput.interface';
import axios from 'axios';

@Component({
  selector: 'app-input-form',
  templateUrl: './input-form.component.html',
  styleUrls: ['./input-form.component.css']
})

export class InputFormComponent {
  equationInput: EquationInput ={
    firstInput: '',
    secondInput: '',
    thirdInput: '',
    fourthInput: '',
    fifthInput: '',
    sixthInput: '',
  }

  validateEquation() : boolean{
    if (this.equationInput.firstInput == '' ||
        this.equationInput.secondInput == '' ||
        this.equationInput.thirdInput == '' ||
        this.equationInput.fourthInput == '' ||
        this.equationInput.fifthInput == '' ||
        this.equationInput.sixthInput == '' 
    ) 
      return false;
    return true;
  }

  async handleEquationSubmit(){
    if (!this.validateEquation())
      return ;
    console.log(this.equationInput);

    //TODO: Aqui vai estar a requisição pra api
    const result = await axios.patch('https://localhost:5001/api/Equation', this.equationInput);
    console.log("result completo", result);
    console.log("result apenas data",result.data);

  }
}

