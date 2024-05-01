create database Assignment_Database
go

use Assignment_Database
go

create table Category -- Thể loại hàng hóa --
(
CategoryID	        nvarchar(30)		not null		primary key,
CategoryName	    nvarchar(MAX),
CategoryDesc	    nvarchar(MAX)
)

create table Products -- Hàng hóa --
(
ProductID	        nvarchar(30)		not null		primary key,
ProductName	        nvarchar(MAX),
ProductDesc	        nvarchar(MAX),
CategoryID          nvarchar(30)        not null,
constraint PK_CategoryID_Cat_Prod foreign key (CategoryID) references Category(CategoryID)
)

create table Customers -- Khách hàng --
(
CustomerID          nvarchar(30)        not null    primary key,
CustomerRealName    nvarchar(MAX),
CustomerDOB         datetime,
CustomerEmail       nvarchar(MAX),
CustomerPassword	nvarchar(MAX)		not null
)

create table Admins -- Quản trị viên --
(
AdminID				nvarchar(30)		not null	primary key,
AdminRealName		nvarchar(MAX),
AdminDOB		    datetime,
AdminEmail		    nvarchar(MAX),
AdminPassword		nvarchar(MAX)		not null
)

create table Cart -- Giỏ hàng --
(
CartID              int     identity(1, 1)          primary key,
CustomerID          nvarchar(30)        not null,
ProductID           nvarchar(30)        not null,
Quantity            int                 not null,
CartDetail          nvarchar(MAX),
OrderCreation       datetime,

constraint PK_CustomerID_Cart_Cus foreign key (CustomerID) references Customers(CustomerID),
constraint PK_ProductID_Cart_Prod foreign key (ProductID) references Products(ProductID)
)

-- creasakxgksjdfsjkdfsj;dfsj;dsjdf;ljgrs;lrkljejkltwjerỉuioueioeru09370932323832-ml;jl;jkljklhgjkljcgnhkjhgjhgcfhyudfgytdgtuytdgftufgxtytdtriyerseasrtrstfgjkhyghkiupogtt8iuuitfdhftugjkgcnbgkjcxghfdfgxhcxhvcghjgkvcngkjchjkgcghcgkhcjkhgkhkjhlvhkvhklvkjvhjkgvb

-- Thêm vào thể loại hàng (2 thể loại) --
insert into Category values
(N'BEVERAGES', N'Đồ uống', N'Các sản phẩm đồ uống như là nước suối, nước ngọt, v.v...'),
(N'FOODSTUFFS', N'Thực phẩm', N'Thực phẩm hàng ngày, bao gồm rau củ quả, thực phẩm chất bột, v.v...')

-- Thêm các mặt hàng (15 hàng) --
insert into Products values
(N'OMACHI_SUON', N'Mỳ Omachi Sườn', N'fdsfdfg', N'FOODSTUFFS'),
(N'OMACHI_BOHAM', N'Mỳ Omachi Bò hẩm', N'fdsfdfg', N'FOODSTUFFS'),
(N'OMACHI_CACHUA', N'Mỳ Omachi Spaghetti', N'fdsfdfg', N'FOODSTUFFS'),
(N'HAOHAO', N'Mỳ Hảo Hảo', N'fdsfdfg', N'FOODSTUFFS'),
(N'HAOHAO_SIUKAY_BO', N'Mỳ Hảo Hảo SiuKay Bò', N'fdsfdfg', N'FOODSTUFFS'),
(N'HAOHAO_SIUKAY_HS', N'Mỳ Hảo Hảo SiuKay Hải sản', N'fdsfdfg', N'FOODSTUFFS'),
(N'HAOHAO_SIUKAY_PM', N'Mỳ Hảo Hảo SiuKay Phô mai', N'fdsfdfg', N'FOODSTUFFS'),
(N'HAOHAO_XAO_TOM', N'Mỳ Xào Hảo Hảo Tôm', N'fdsfdfg', N'FOODSTUFFS'),
(N'HAOHAO_MODERN_LT', N'Mỳ Ly Hảo Hảo Lẩu Thái', N'fdsfdfg', N'FOODSTUFFS'),
(N'C2_CHANH', N'C2 Chanh', N'fdsfdfg', N'BEVERAGES'),
(N'C2_TAO', N'C2 Táo', N'fdsfdfg', N'BEVERAGES'),
(N'C2_BACHA_CHANH', N'C2 Bạc hà Chanh', N'fdsfdfg', N'BEVERAGES'),
(N'C2_BACHA_CHERRY', N'C2 Bạc hà Cherry', N'fdsfdfg', N'BEVERAGES'),
(N'C2_DUALUOI', N'C2 Dưa lưới', N'fdsfdfg', N'BEVERAGES'),
(N'C2_DAO', N'C2 Đào', N'fdsfdfg', N'BEVERAGES')

-- Thêm khách hàng (3 người) --
insert into Customers values
(N'nguyenvananh1005', N'Nguyễn Văn Anh', N'1995-01-01 12:34:56.789', N'nguyenvananh1005@gmail.com', N'123456'),
(N'nguoidungkhac', N'Trần Thị Bách', N'1996-09-19 08:32:12.232', N'cooldude03@gmail.com', N'123456')

insert into Admins values
(N'main_assmin', N'Admin', N'1998-05-27 17:32:51.045', N'a@a.com', N'123456')