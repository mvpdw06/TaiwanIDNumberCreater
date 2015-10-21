  /// <summary>
	/// 身份證字號產生器
	/// </summary>
	/// <param name="sex">性別 M:男, F:女</param>
	/// <returns></returns>
	public string IdNumber_Generate(string sex)
	{
		//"A.台北市","B.台中市","C.基隆市","D.台南市","E.高雄市","F.新北市",
		//"G.宜蘭縣","H.桃園縣","I.嘉義市","J.新竹縣","K.苗栗縣","L.台中縣",
		//"M.南投縣","N.彰化縣","O.新竹市","P.雲林縣","Q.嘉義縣","R.台南縣",
		//"S.高雄縣","T.屏東縣","U.花蓮縣","V.台東縣","W.金門縣","X.澎湖縣",
		//"Y.陽明山管理局","Z.連江縣"
		string[] county_E = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
		int[] county_i = { 10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 20, 21, 35, 23, 24, 25, 26, 27, 28, 29, 32, 30, 31, 33 };

		//出生地隨機產生
		Random Randon_ContryIndex = new Random(Guid.NewGuid().GetHashCode());
		int ContryIndex = Randon_ContryIndex.Next(0, 23);
		//取得城市代碼 ex:A, B, C.....
		string id = county_E[ContryIndex];
		int c_i = county_i[ContryIndex];

		if (sex.Equals("M"))
			sex = "1";
		else if (sex.Equals("F"))
			sex = "2";


		//亂數審核碼
		Random Randon_ChkCode = new Random(Guid.NewGuid().GetHashCode());
		int rand_i = Randon_ChkCode.Next(0, 10000000);

		//取得城市第一與第二碼X1, X2
		int X1 = Convert.ToInt32(c_i.ToString().Substring(0, 1));
		int X2 = Convert.ToInt32(c_i.ToString().Substring(1, 1));

		//檢查碼取得 X1 + X2 * 9 + sex * 8
		int check = X1 + 9 * X2 + Convert.ToInt32(sex) * 8;
		//計算審核碼
		for (int i = 7; i >= 1; i--)
		{
			check += ((rand_i / (int)Math.Pow(10, i - 1)) % 10) * i;
		}
		check = (10 - (check % 10)) % 10;

		//計算審核碼
		id += sex + rand_i.ToString().PadLeft(7, '0') + check.ToString();
		return id;
	}
