using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Common.CreateClassFromDatabase
{

    //https://exceptionnotfound.net/mapping-datatables-and-datarows-to-objects-in-csharp-and-net-using-reflection/


    //https://codverter.com/src/sqltoclass?prg=1&db=1&sample=1
    public class Product
    {
        public int Id { get; set; }
        public string FullUrl { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string Color { get; set; }
        public string Vendor { get; set; }
        public DateTime LastUpdate { get; set; }
        public int Quantity { get; set; }
        public long FacebookLikes { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public byte Type { get; set; }
        public bool IsExist { get; set; }

        public Product(int Id_, string FullUrl_, string ProductName_, string Description_, DateTime CreationDate_, string Color_, string Vendor_, DateTime LastUpdate_, int Quantity_, long FacebookLikes_, decimal Price_, decimal Weight_, byte Type_, bool IsExist_)
        {
            this.Id = Id_;
            this.FullUrl = FullUrl_;
            this.ProductName = ProductName_;
            this.Description = Description_;
            this.CreationDate = CreationDate_;
            this.Color = Color_;
            this.Vendor = Vendor_;
            this.LastUpdate = LastUpdate_;
            this.Quantity = Quantity_;
            this.FacebookLikes = FacebookLikes_;
            this.Price = Price_;
            this.Weight = Weight_;
            this.Type = Type_;
            this.IsExist = IsExist_;
        }
    }
}

/*

 //TypeScript   
   export class Product
{
	private _Id: number;
	public get Id(): number
	{
		return this._Id;
	}
	public set Id(val: number)
	{
		this._Id = val;
	}

	private _FullUrl: string;
	public get FullUrl(): string
	{
		return this._FullUrl;
	}
	public set FullUrl(val: string)
	{
		this._FullUrl = val;
	}

	private _ProductName: string;
	public get ProductName(): string
	{
		return this._ProductName;
	}
	public set ProductName(val: string)
	{
		this._ProductName = val;
	}

	private _Description: string;
	public get Description(): string
	{
		return this._Description;
	}
	public set Description(val: string)
	{
		this._Description = val;
	}

	private _CreationDate: Date;
	public get CreationDate(): Date
	{
		return this._CreationDate;
	}
	public set CreationDate(val: Date)
	{
		this._CreationDate = val;
	}

	private _Color: string;
	public get Color(): string
	{
		return this._Color;
	}
	public set Color(val: string)
	{
		this._Color = val;
	}

	private _Vendor: string;
	public get Vendor(): string
	{
		return this._Vendor;
	}
	public set Vendor(val: string)
	{
		this._Vendor = val;
	}

	private _LastUpdate: Date;
	public get LastUpdate(): Date
	{
		return this._LastUpdate;
	}
	public set LastUpdate(val: Date)
	{
		this._LastUpdate = val;
	}

	private _Quantity: number;
	public get Quantity(): number
	{
		return this._Quantity;
	}
	public set Quantity(val: number)
	{
		this._Quantity = val;
	}

	private _FacebookLikes: number;
	public get FacebookLikes(): number
	{
		return this._FacebookLikes;
	}
	public set FacebookLikes(val: number)
	{
		this._FacebookLikes = val;
	}

	private _Price: number;
	public get Price(): number
	{
		return this._Price;
	}
	public set Price(val: number)
	{
		this._Price = val;
	}

	private _Weight: number;
	public get Weight(): number
	{
		return this._Weight;
	}
	public set Weight(val: number)
	{
		this._Weight = val;
	}

	private _Type: number;
	public get Type(): number
	{
		return this._Type;
	}
	public set Type(val: number)
	{
		this._Type = val;
	}

	private _IsExist: boolean;
	public get IsExist(): boolean
	{
		return this._IsExist;
	}
	public set IsExist(val: boolean)
	{
		this._IsExist = val;
	}


	constructor (Id_: number,FullUrl_: string,ProductName_: string,Description_: string,CreationDate_: Date,Color_: string,Vendor_: string,LastUpdate_: Date,Quantity_: number,FacebookLikes_: number,Price_: number,Weight_: number,Type_: number,IsExist_: boolean)
	{
		this.Id = Id_;
		this.FullUrl = FullUrl_;
		this.ProductName = ProductName_;
		this.Description = Description_;
		this.CreationDate = CreationDate_;
		this.Color = Color_;
		this.Vendor = Vendor_;
		this.LastUpdate = LastUpdate_;
		this.Quantity = Quantity_;
		this.FacebookLikes = FacebookLikes_;
		this.Price = Price_;
		this.Weight = Weight_;
		this.Type = Type_;
		this.IsExist = IsExist_;
	}
}



    
    //JavaScript
 function Product(
_Id,_FullUrl,_ProductName,_Description,_CreationDate,_Color,_Vendor,_LastUpdate,_Quantity,_FacebookLikes,_Price,_Weight,_Type,_IsExist
)
{
this.Id = _Id;
this.FullUrl = _FullUrl;
this.ProductName = _ProductName;
this.Description = _Description;
this.CreationDate = _CreationDate;
this.Color = _Color;
this.Vendor = _Vendor;
this.LastUpdate = _LastUpdate;
this.Quantity = _Quantity;
this.FacebookLikes = _FacebookLikes;
this.Price = _Price;
this.Weight = _Weight;
this.Type = _Type;
this.IsExist = _IsExist;
}
*/


/*
 * CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullUrl] [nvarchar](max) NOT NULL,
	[ProductName] [nvarchar](max) NULL,
	[Description] [nvarchar](100) NULL,
	[CreationDate] [datetime] NULL,
	[Color] [nvarchar](50) NULL,
	[Vendor] [nvarchar](255) NULL,
	[LastUpdate] [datetime] NULL,
	[Quantity] [int] NOT NULL,
	[FacebookLikes] [bigint] NULL,
	[Price] [MONEY] NULL,
	[Weight] [DECIMAL](18,2) NULL,
	[Type] [TINYINT] NULL,
	[IsExist] [bit] NULL,
	PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
*/
