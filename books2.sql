create database boook
use boook
create table Books (
	ID int Primary key,
	Name NVARCHAR(50) not null,
	Autor Varchar(20) not null,
	Price Money not null,
	Pages int not null,
	date_sortie date,
)
drop table Books
insert into Books values(1,'HTML5','Tim',1500,100)
insert into Books values(2,'Java','John',2500,160)
insert into Books values(3,'C-Sharp','Microsoft',2000,170)
--insert into Books values(,'','',,)
drop proc GetBooksCat 
create proc GetBooksCat 
as begin
select * from catégorie
select * from books

select b.ID,b.Name,b.Autor,b.Price,b.Pages,b.date_sortie,c.nom_categorie from Books b, catégorie c where c.id_categorie=b.id_cat
end
 CREATE TABLE catégorie(
	id_categorie int primary key identity(10,10),
	nom_categorie nvarchar(50))
 