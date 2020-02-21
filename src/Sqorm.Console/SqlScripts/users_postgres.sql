-- run this query separately first and proceeding to the next block
CREATE DATABASE "SqormTestDb";

-- after database is created, switch to 'SqormTestDb' database and public schema
-- and run the following block to create users table
-- and populate test data
CREATE TABLE "SqormTestDb".public.users
(
	id bigserial PRIMARY KEY,
	username varchar(64) NOT NULL unique,
	password varchar(64) NOT NULL,
	is_deleted bool DEFAULT false,
	date_created timestamp without time zone DEFAULT now()
);

INSERT INTO "SqormTestDb".public.users (id, username, password) values(1, 'admin', 'adminpass');
INSERT INTO "SqormTestDb".public.users (id, username, password) values(2, 'user', 'userpass');
INSERT INTO "SqormTestDb".public.users (id, username, password) values(3, 'guest', 'guestpass');
