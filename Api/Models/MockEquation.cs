using System;

/// <summary>
/// Summary description for MockEquation
/// </summary>
/// 
namespace Api.Models {
	public class MockEquation {
		public string eq1;
		public string eq2;
		public string eq3;
		public string eq4;
		public string eq5;
		public string eq6;
		public string eq7;
		public string eq8;
		public string eq9;
		public string eq10;
		public string eq11;
		public string eq12;
		public string eq13;
		public string eq14;

		public MockEquation() {
			eq1 = "4*11-2";
			eq2 = "50-8*2";
			eq3 = "182-63";
			eq4 = "21*2-0";
			eq5 = "10*4+2";
			eq6 = "42+0+0";
			eq7 = "000042";
			eq8 = "42*1-0";
			eq9 = "21*2+0";
			eq10 = "21+021";
			eq11 = "066-24";
			eq12 = "33+9+0";
			eq13 = "14*3+0";
			eq14 = "7*6-00";
    }

		public string[] ToArray() {
			return new string[] { eq1, eq2, eq3, eq4, eq5, eq6, eq7, eq8, eq9, eq10, eq11, eq12, eq13, eq14 };
		}
	}
}
