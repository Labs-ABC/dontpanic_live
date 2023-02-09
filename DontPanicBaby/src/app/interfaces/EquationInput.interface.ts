export default class EquationInput {
	firstInput: string;
	secondInput: string;
	thirdInput: string;
	fourthInput: string;
	fifthInput: string;
  sixthInput: string;

  constructor(value = '') {
    this.firstInput = value;
    this.secondInput = value;
    this.thirdInput = value;
    this.fourthInput = value;
    this.fifthInput = value;
    this.sixthInput = value;
  }

  clear(value = ''): void {
    this.firstInput = value;
    this.secondInput = value;
    this.thirdInput = value;
    this.fourthInput = value;
    this.fifthInput = value;
    this.sixthInput = value;
  }
}
