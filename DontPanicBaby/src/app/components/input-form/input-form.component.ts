import { Component } from '@angular/core';
import EquationInput from 'src/app/interfaces/EquationInput.interface';
import axios from 'axios';

@Component({
  selector: 'app-input-form',
  templateUrl: './input-form.component.html',
  styleUrls: ['./input-form.component.css']
})

export class InputFormComponent {
  equationInput: EquationInput = new EquationInput();

  equationResult: EquationInput = new EquationInput('input');

  equationCorrect: EquationInput = new EquationInput('C');

  lastEquation: EquationInput = new EquationInput();

  showMessage: boolean = false;

  message: string = 'Congratulations! You found the hidden equation.';

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

  isCorrectEquation(result: EquationInput): boolean {
    return this.equationCorrect.equals(result);
  }

  async handleEquationSubmit(){
    if (!this.validateEquation())
      return ;

    //TODO: Aqui vai estar a requisição pra api
    const result = await axios.patch('http://localhost:5000/api/Equation', this.equationInput);
    
    if (this.equationInput.equals(result.data)) {
      //this.equationInput.clear('');
      return;
    }
    //Valida A resposta
    this.validateApiResponse(result.data);
    this.showMessage = this.isCorrectEquation(result.data);

    //copia o input para a linha de cima
    this.lastEquation.copy(this.equationInput);

    //apaga a linha de baixo 
    this.equationInput.clear('');
   }
}

