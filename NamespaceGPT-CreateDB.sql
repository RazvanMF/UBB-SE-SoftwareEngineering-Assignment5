CREATE TABLE AppUser (
	id INT IDENTITY,
	username VARCHAR(50),
	password VARCHAR(50)
);

CREATE TABLE Marketplace (
	id INT IDENTITY,
	marketplacename VARCHAR(50),
	websiteurl VARCHAR(200),
	country VARCHAR(50)
);

CREATE TABLE Product (
	id INT IDENTITY,
	name VARCHAR(50),
	category VARCHAR(50),
	description VARCHAR(200),
	brand VARCHAR(50),
	imageURL VARCHAR(200),
	attributes VARCHAR(200)
);

CREATE TABLE Review (
	id INT IDENTITY,
	productId INT,
	userId INT,
	title VARCHAR(50),
	description VARCHAR(200),
	rating INT
);

CREATE TABLE Listing (
	id INT IDENTITY,
	product INT,
	marketplace INT,
	price INT
);

CREATE TABLE FavouriteProduct (
	id INT IDENTITY,
	userId INT,
	productId INT
);

CREATE TABLE BackInStockAlerts (
    id INT IDENTITY PRIMARY KEY,
    UserId INT,
    ProductId INT,
);

CREATE TABLE PriceDropAlerts (
    id INT IDENTITY PRIMARY KEY,
    UserId INT,
    ProductId INT,
    OldPrice DECIMAL(10, 2),
    NewPrice DECIMAL(10, 2),
);

CREATE TABLE NewProductAlerts (
    id INT IDENTITY PRIMARY KEY,
    UserId INT,
    ProductId INT,
);

CREATE TABLE AdRecommendation (
    id INT PRIMARY KEY Identity(1,1),
    listingId INT,
);

SELECT * FROM AppUser
SELECT * FROM Marketplace

SELECT * FROM Product

INSERT INTO Product VALUES ('samsung a40', 'phones', 'nice phone', 'samsung', 'https://s13emagst.akamaized.net/products/20881/20880622/images/res_381d8711510238431d78e9122a8c18d3.jpg', 'colour:blue;memory:128GB');
INSERT INTO Product VALUES ('GTB1756VK', 'car parts', 'A good turbo-upgrade for the 1.9 TDI', 'Garett', 'https://forums.tdiclub.com/proxy.php?image=http%3A%2F%2Fwww.darkside-developments.co.uk%2F%2Fimages%2Fproducts%2FGTB%2520%281%29.JPG&hash=60187d69a88c934a008304453cc8b48b', 'colour:gray;targetHP:200,lag:minimal');
INSERT INTO FavouriteProduct VALUES (7, 2);
INSERT INTO FavouriteProduct VALUES (7, 1);

INSERT INTO Marketplace VALUES ('Amazon', '...', '...');
INSERT INTO Marketplace VALUES ('Emag', '...', '...');
INSERT INTO Marketplace VALUES ('Ebay', '...', '...');

INSERT INTO Listing VALUES (1, 1, 100);
INSERT INTO Listing VALUES (1, 2, 110);
INSERT INTO Listing VALUES (1, 3, 120);
INSERT INTO Listing VALUES (2, 1, 99);
INSERT INTO Listing VALUES (2, 2, 109);

INSERT INTO Review VALUES (1, 7, 'Very good', 'I like this phone', 5);
INSERT INTO Review VALUES (2, 7, 'Bad', 'I hate this phone', 1);
INSERT INTO Review VALUES (2, 7, 'It is ok', 'Nothin spectacular about it, average', 3);
INSERT INTO Review VALUES (1, 1, 'Nice', 'I am happy with this phone', 4);

SELECT * FROM Review

SELECT * FROM Listing


Insert into Product(name,category,description,brand,imageUrl,attributes) Values('Fridge','Appliances','White 2 metres tall','Beko','https://www.bigchill.uk/Images/Products/UK-Retro-Fridge/RetroEuroFridge-White-Md.jpg','colour:white');
Insert into Product(name,category,description,brand,imageUrl,attributes) Values('Iphone','phones','nice phone','Apple','https://cdn.cs.1worldsync.com/2c/5f/2c5fa58c-4955-4d9e-a2c1-7c4ae9f03574.jpg','colour:black');
Insert into Product(name,category,description,brand,imageUrl,attributes) Values('Iphone12','phones','nice phone2','Apple','https://images-cdn.ubuy.co.in/64b12805d5e6be5f96724809-apple-iphone-12-mini-64gb-128gb-256gb.jpg','colour:rainbow');


Insert into Product(name,category,description,brand,imageUrl,attributes) Values('Mouse','Computer Accessories','Office mouse suitable for anyone','lenovo','https://s1.cel.ro/images/mari/2022/08/09/Lenovo-4Y50X88822-mouse-uri-Ambidextru-Bluetooth-Optice-2400-DPI.jpg','colour:black;size:slim;type:dual'),
																				('Keyboard','Computer Accessories','Office mouse suitable for anyone','lenovo','https://s1.cel.ro/images/mari/2022/08/09/Lenovo-4Y50X88822-mouse-uri-Ambidextru-Bluetooth-Optice-2400-DPI.jpg','colour:black;size:slim;type:dual');


SELECT * FROM Product

update Product SET imageURL='https://m.media-amazon.com/images/I/71yGtauB-AL._AC_SL1500_.jpg' WHERE id=8
update Product SET imageURL='https://images.theconversation.com/files/265294/original/file-20190322-36283-1me4pb6.jpg?ixlib=rb-1.1.0&rect=0%2C0%2C3772%2C3342&q=45&auto=format&w=926&fit=clip' WHERE id=7
update Product SET imageURL='https://www.cnet.com/a/img/resize/887997d313cda859afd73f96615c96a51338a5ca/hub/2020/10/18/bdb7ea97-cb99-48d8-a69c-38d26109f33b/05-iphone-12-pro-2020.jpg?auto=webp&fit=crop&height=900&width=1200' WHERE id=6
