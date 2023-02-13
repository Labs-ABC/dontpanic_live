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

  copy(rhs: EquationInput) : void{
    this.firstInput = rhs.firstInput;
    this.secondInput = rhs.secondInput;
    this.thirdInput = rhs.thirdInput;
    this.fourthInput = rhs.fourthInput;
    this.fifthInput = rhs.fifthInput;
    this.sixthInput = rhs.sixthInput;
  }

  equals(rhs: EquationInput): boolean {
    if (this.firstInput != rhs.firstInput ||
      this.secondInput != rhs.secondInput ||
      this.thirdInput != rhs.thirdInput ||
      this.fourthInput != rhs.fourthInput ||
      this.fifthInput != rhs.fifthInput ||
      this.sixthInput != rhs.sixthInput)
      return false;
    return true;
  }
}
