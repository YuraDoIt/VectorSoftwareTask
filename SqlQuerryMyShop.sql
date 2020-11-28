create database if not exists MyShop;
use MyShop;

/*Create Suppliers*/
create table Suppliers(
	SupplierID int not null auto_increment,
    SupplierName varchar(255) not null,
    City varchar(255) not null,
    Country varchar(255) not null,
    primary key(SupplierID)
)
ENGINE = InnoDB;
/*insert data to Suppliers*/
insert into Suppliers(SupplierID, SupplierName, City, Country)
values(1,"Exotic Liquid","London","UK"),
(2,"New Orleans Cajun Delights", "New Orleans", "USA"),
(3,"Grandma Kelly’s Homestead", "Ann Arbor" , "USA"),
(4,"Tokyo Traders" ,"Tokyo", "Japan"),
(5,"Cooperativa de Quesos ‘Las Cabras’", "Oviedo", "Spain");



/*Create Categories*/
create table Categories(
	CategoryID int not null,
    CategoryName varchar(255),
    DescriptionC varchar(500),
    primary key(CategoryID)
)
ENGINE = InnoDB;
/*insert data to Catefories*/
insert into Categories(CategoryID, CategoryName, DescriptionC)
values (1, "Beverages", "Soft drinks, coffees, teas, beers, and ales"),
(2, "Condiments", "Sweet and savory sauces, relishes, spreads, and seasonings"),
(3, "Confections", "Desserts, candies, and sweet breads"),
(4, "Dairy Products", "Cheeses"),
(5, "Grains/Cereals", "Breads, crackers, pasta, and cereal");



/*create Products*/
create table Products (
	ProductID int not null auto_increment,
    ProductName varchar(255) NOT NULL,
    SupplierID int ,
    CategoryID int,
    Price DECIMAL(8,2),
    primary key(ProductID),
    foreign key(SupplierID) references Suppliers(SupplierID),
    foreign key(CategoryID) references Categories(CategoryID)
)
ENGINE = InnoDB;
/*Insert data to Products*/
insert into Products (ProductID, ProductName, SupplierID, CategoryID, Price)
values(1, "Chais", 1, 1, 18.00),
(2, "Chang",1,1,19.00),
(3, "Aniseed Syrup",1, 2, 10.00),
(4, "Chef Anton’s Cajun Seasoning", 2, 2, 22.00),
(5, "Chef Anton’s Gumbo Mix", 2, 2, 21.35);

/*Select product with product name that begin with "C"*/
Select * 
From Products 
where Products.ProductName like 'C%';

/*Select product with the smallest price*/
Select * 
From Products
where Price = (
	Select min(Price)
    From Products
); 

select * from products;

/*Select cost of all products from the USA*/
Select sum(Price) as cost
From Products 
inner join Suppliers ON Products.SupplierID = Suppliers.SupplierID 
where Suppliers.Country = 'USA';

/*Select suppliers that supply Condiments*/
Select Suppliers.SupplierID, SupplierName, City, Country
from Suppliers 
inner join Products on Suppliers.SupplierID = Products.SupplierID
inner join Categories on Products.CategoryID = Categories.CategoryID
where Categories.CategoryName = "Condiments"; 

/*Insert to database new supplier with name "Norske Meierier" city "lviv"
country "Ukraine" which will supply new product with name "Green tea", price 10
and related to category with name Beverages*/

insert into Suppliers(SupplierName, City, Country)
values("Norske Meierier", "Lviv", "Ukraine");
insert into Products(SupplierID,ProductName, Price, CategoryID)
values (6,"Green tea", 10, 1);



/*Drop table Test*/
drop table Products;
drop table Suppliers;
drop table Categories;

