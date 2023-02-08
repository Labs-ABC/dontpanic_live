import { Component } from '@angular/core';
import EquationInput from 'src/app/interfaces/EquationInput.interface';
import axios from 'axios';

@Component({
  selector: 'app-input-form',
  templateUrl: './input-form.component.html',
  styleUrls: ['./input-form.component.css']
})

export class InputFormComponent {
  equationInput: EquationInput = {
    firstInput: '',
    secondInput: '',
    thirdInput: '',
    fourthInput: '',
    fifthInput: '',
    sixthInput: '',
  }

  equationResult: EquationInput = {
    firstInput: 'input',
    secondInput: 'input',
    thirdInput: 'input',
    fourthInput: 'input',
    fifthInput: 'input',
    sixthInput: 'input',
  }

  validateEquation() : boolean {
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

  validateApiData(data : string) : string {
    if (data == 'C')
      return 'input__correct__position';
    if (data == 'T')
      return 'input__wrong__position';
    if (data == 'X')
      return 'input__not__found';
    return 'input';
  }

  validateApiResponse(result : EquationInput) {
    this.equationResult.firstInput = this.validateApiData(result.firstInput);
    this.equationResult.secondInput = this.validateApiData(result.secondInput);
    this.equationResult.thirdInput = this.validateApiData(result.thirdInput);
    this.equationResult.fourthInput = this.validateApiData(result.fourthInput);
    this.equationResult.fifthInput = this.validateApiData(result.fifthInput);
    this.equationResult.sixthInput = this.validateApiData(result.sixthInput);
  }

  async handleEquationSubmit(){
    if (!this.validateEquation())
      return ;
    console.log(this.equationInput);

    //TODO: Aqui vai estar a requisição pra api
    const result = await axios.patch('https://localhost:5001/api/Equation', this.equationInput);
    console.log("result completo", result);
    console.log("result apenas data", result.data);
    this.validateApiResponse(result.data);
  }
}

