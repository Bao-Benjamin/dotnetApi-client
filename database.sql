use bookStore;
create table book(
	
	id int primary key auto_increment,

	name varchar(20),
    
	quantity int,
    
	publisher varchar(50),
    
	unit_price varchar(20),
    
	price int
);

insert into book values(1,"Harry Pooster",20,"Rowling","usd",20);

insert into book values(2,"KingDom",20,"Dat","usd",30);