-- MySQL Workbench Forward Engineering

/* SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0; */
/* SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0; */
/* SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES'; */

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema RatingEmpresas
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema RatingEmpresas
-- -----------------------------------------------------
USE master;
GO

DROP DATABASE RatingEmpresas;
GO

CREATE DATABASE RatingEmpresas COLLATE LATIN1_GENERAL_100_CI_AS_SC_UTF8;
GO

ALTER LOGIN sa ENABLE ;  
GO  
ALTER LOGIN sa WITH PASSWORD = '123456' ;  
GO  

USE [RatingEmpresas] ;
GO

-- -----------------------------------------------------
-- Table `RatingEmpresas`.`regions`
-- -----------------------------------------------------
CREATE TABLE regions (
  [id] CHAR(2) NOT NULL,
  [name] VARCHAR(30) NOT NULL,
  PRIMARY KEY ([id]))
 ;


-- -----------------------------------------------------
-- Table `RatingEmpresas`.`provinces`
-- -----------------------------------------------------
CREATE TABLE provinces (
  [id] CHAR(2) NOT NULL,
  [name] VARCHAR(30) NOT NULL,
  PRIMARY KEY ([id]))
 ;


-- -----------------------------------------------------
-- Table `RatingEmpresas`.`cities`
-- -----------------------------------------------------
CREATE TABLE cities (
  [id] CHAR(36) NOT NULL,
  [name] VARCHAR(60) NOT NULL,
  [region_id] CHAR(2) NOT NULL,
  [province_id] CHAR(2) NOT NULL,
  PRIMARY KEY ([id])
 ,
  CONSTRAINT [fk_cities_region_id_region_id]
    FOREIGN KEY ([region_id])
    REFERENCES regions ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_cities_province_id_province_id]
    FOREIGN KEY ([province_id])
    REFERENCES provinces ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
 ;

CREATE INDEX [cities_fk_region_id_regions_id_idx] ON cities ([region_id] ASC);
CREATE INDEX [cities_fk_province_id_provinces_id_idx] ON cities ([province_id] ASC);


-- -----------------------------------------------------
-- Table `RatingEmpresas`.`sectors`
-- -----------------------------------------------------
CREATE TABLE sectors (
  [id] CHAR(36) NOT NULL,
  [sector] VARCHAR(45) NOT NULL,
  PRIMARY KEY ([id]),
  CONSTRAINT [sector_UNIQUE] UNIQUE  ([sector] ASC))
 ;


-- -----------------------------------------------------
-- Table `RatingEmpresas`.`users`
-- -----------------------------------------------------
CREATE TABLE users (
  [id] CHAR(36) NOT NULL,
  [name] VARCHAR(45) NOT NULL,
  [email] VARCHAR(45) NOT NULL,
  [password] VARCHAR(255) NOT NULL,
  [linkedin] VARCHAR(255) NULL,
  [role] CHAR(1) NOT NULL,
  [created_at] DATETIME2(0) NOT NULL,
  [activated_at] DATETIME2(0) NULL,
  [modified_at] DATETIME2(0) NULL,
  [deleted_at] DATETIME2(0) NULL,
  PRIMARY KEY ([id]),
  CONSTRAINT [email_unique] UNIQUE  ([email]))
 ;


 -- -----------------------------------------------------
-- Table `RatingEmpresas`.`users_activation`
-- -----------------------------------------------------
CREATE TABLE users_activation (
  [id] CHAR(36) NOT NULL,
  [verification_code] CHAR(36) NOT NULL,
  [created_at] DATETIME2(0) NOT NULL,
  [verified_at] DATETIME2(0) NULL,
  PRIMARY KEY ([id]),
    CONSTRAINT [fk_user_activation_id_user_id]
    FOREIGN KEY ([id])
    REFERENCES users ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION )
 ;


-- -----------------------------------------------------
-- Table `RatingEmpresas`.`companies`
-- -----------------------------------------------------
CREATE TABLE companies (
  [id] CHAR(36) NOT NULL,
  [name] VARCHAR(60) NOT NULL,
  [description] VARCHAR(1000) NULL,
  [sector_id] CHAR(36) NOT NULL,
  [url_web] VARCHAR(255) NULL,
  [linkedin] VARCHAR(255) NULL,
  [address] VARCHAR(60) NULL,
  [sede_id] CHAR(36) NOT NULL,
  [url_logo] VARCHAR(255) NULL,
  [user_id] CHAR(36) NOT NULL,
  [created_at] DATETIME2(0) NOT NULL,
  [updated_at] DATETIME2(0) NULL DEFAULT NULL,
  PRIMARY KEY ([id])
 ,
  CONSTRAINT [name_UNIQUE] UNIQUE  ([name] ASC),
  CONSTRAINT [fk_companies_sector_id_sector_id]
    FOREIGN KEY ([sector_id])
    REFERENCES sectors ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_companies_sede_id_city_id]
    FOREIGN KEY ([sede_id])
    REFERENCES cities ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_companies_user_id_user_id]
    FOREIGN KEY ([user_id])
    REFERENCES users ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
 ;
-- CREATE INDEX [fk_companies_sector_id_sector_id_idx] ON sectors ([sector_id] ASC);
-- CREATE INDEX [fk_companies_sede_id_city_id_idx] ON cities ([sede_id] ASC);
-- CREATE INDEX [fk_companies_user_id_user_id_idx] ON users ([user_id] ASC);

-- -----------------------------------------------------
-- Table `RatingEmpresas`.`companies_cities`
-- -----------------------------------------------------
CREATE TABLE companies_cities (
  [city_id] CHAR(36) NOT NULL,
  [company_id] CHAR(36) NOT NULL,
  PRIMARY KEY ([city_id], [company_id])
 ,
  CONSTRAINT [fk_companies_cities_city_id_city_id]
    FOREIGN KEY ([city_id])
    REFERENCES cities ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_companies_cities_company_id_company_id]
    FOREIGN KEY ([company_id])
    REFERENCES companies ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
 ;
-- CREATE INDEX [companies_cities_fk_company_id_idx] ON companies_cities ([company_id] ASC);


-- -----------------------------------------------------
-- Table `RatingEmpresas`.`positions`
-- -----------------------------------------------------
CREATE TABLE positions (
  [id] CHAR(36) NOT NULL,
  [name] VARCHAR(60) NOT NULL,
  PRIMARY KEY ([id]),
  CONSTRAINT [name] UNIQUE  ([name] ASC))
 ;


-- -----------------------------------------------------
-- Table `RatingEmpresas`.`reviews`
-- -----------------------------------------------------
CREATE TABLE reviews (
  [id] CHAR(36) NOT NULL,
  [user_id] CHAR(36) NOT NULL,
  [position_id] CHAR(36) NOT NULL,
  [start_year] SMALLINT CHECK ([start_year] > 0) NOT NULL,
  [end_year] SMALLINT CHECK ([end_year] > 0) NULL,
  [salary] DECIMAL(10,2) NULL,
  [inhouse_training] CHAR(1) NOT NULL,
  [growth_opportunities] CHAR(1) NOT NULL,
  [work_enviroment] CHAR(1) NOT NULL,
  [personal_life] CHAR(1) NOT NULL,
  [salary_valuation] CHAR(1) NOT NULL,
  [comment_title] VARCHAR(30) NOT NULL,
  [comment] VARCHAR(1000) NOT NULL,
  [created_at] DATETIME2(0) NOT NULL,
  [deleted_at] DATETIME2(0) NULL,
  [city_id] CHAR(36) NOT NULL,
  [company_id] CHAR(36) NOT NULL,
  PRIMARY KEY ([id])
 ,
  CONSTRAINT [fk_reviews_user_id_user_id]
    FOREIGN KEY ([user_id])
    REFERENCES users ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_reviews_position_id_position_id]
    FOREIGN KEY ([position_id])
    REFERENCES positions ([id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT [fk_reviews_city_id_city_id_company_id_company_id]
    FOREIGN KEY (city_id, company_id) REFERENCES companies_cities (city_id, company_id)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
  -- CONSTRAINT [fk_reviews_city_id_city_id]
  --  FOREIGN KEY ([city_id])
  --  REFERENCES companies_cities ([city_id])
  --  ON DELETE NO ACTION
  --  ON UPDATE NO ACTION,
  -- CONSTRAINT [fk_reviews_company_id_company_id]
  --  FOREIGN KEY ([company_id])
  --  REFERENCES companies_cities ([company_id])
  --  ON DELETE NO ACTION
  --  ON UPDATE NO ACTION)
 ;

 -- 
 


--CREATE INDEX [fk_reviews_1_idx] ON reviews ([user_id] ASC);
--CREATE INDEX [fk_positions_position_id_position_id_idx] ON reviews ([position_id] ASC);
--CREATE INDEX [fk_reviews_city_id_city_id_idx] ON reviews ([city_id] ASC);
--CREATE INDEX [fk_reviews_company_id_company_id_idx] ON reviews ([company_id] ASC);


/* SET SQL_MODE=@OLD_SQL_MODE; */
/* SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS; */
/* SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS; */
