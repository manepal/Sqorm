CREATE DATABASE SqormTestDb;
GO

USE SqormTestDb;
CREATE TABLE users(
	id bigint identity primary key,
	username varchar(64) not null unique,
	password varchar(64) not null,
	is_deleted bit not null default(0),
	date_created datetime2 not null default(getutcdate())
);

INSERT INTO users(username, password) VALUES('admin', 'adminpass');
INSERT INTO users(username, password) VALUES('user', 'userpass');
INSERT INTO users(username, password) VALUES('guest', 'guestpass');

GO
