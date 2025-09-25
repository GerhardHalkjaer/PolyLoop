CREATE LOGIN api_user WITH PASSWORD = 'StrongPassword123!';
USE PolyLoop;
CREATE USER api_user FOR LOGIN api_user;
ALTER ROLE db_owner ADD MEMBER api_user;