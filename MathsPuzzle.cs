using System;

public class MathsPuzzle {
	public int firstNumber, secondNumber, userAnswer;
	public char mathOperator;
	private bool puzzleStatus;
	
	public MathsPuzzle(int firstNumber, int secondNumber, int mathOperator) {
		this.firstNumber = firstNumber;
		this.secondNumber = secondNumber;
		
		if (mathOperator == 1) {
			this.mathOperator = '+';
		}
		else if (mathOperator  == 2) {
			this.mathOperator = '-';
		}
		else if (mathOperator  == 3) {
			this.mathOperator = '*';
		}
		else if (mathOperator  == 4) {
			this.mathOperator = '/';
		}
		
		this.puzzleStatus = false;
	}

	public bool getStatus() {
		return this.puzzleStatus;
	}
	
	// Need to display this via Unity
	public void displayQuestion() {
		Console.WriteLine("{0} {1} {2}", this.firstNumber, this.mathOperator, this.secondNumber);
	}

	// Get user input from an answer box in unity?
	public void getUserInput() {
		this.displayQuestion();
		this.userAnswer = Convert.ToInt32(Console.ReadLine());
	}
	
	public void solvePuzzle() {
		switch (this.mathOperator) {
            case '+': this.puzzleStatus = (this.firstNumber + this.secondNumber) == this.userAnswer;
					  break;
			case '-': this.puzzleStatus = (this.firstNumber - this.secondNumber) == this.userAnswer;
					  break;
			case '*': this.puzzleStatus = (this.firstNumber * this.secondNumber) == this.userAnswer;
					  break;
			case '/': this.puzzleStatus = (this.firstNumber / this.secondNumber) == this.userAnswer;
					  break;
        }	
	}
}