--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2
-- Dumped by pg_dump version 15.3

-- Started on 2023-09-02 03:03:04

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 3352 (class 1262 OID 28058)
-- Name: FlightDatabase; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "FlightDatabase" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United States.1252';


ALTER DATABASE "FlightDatabase" OWNER TO postgres;

\connect "FlightDatabase"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 214 (class 1259 OID 28059)
-- Name: Documents; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Documents" (
    "Id" bigint NOT NULL,
    "DocumentType" character varying NOT NULL,
    "DocumentNumber" character varying NOT NULL,
    "PassengerId" bigint NOT NULL
);


ALTER TABLE public."Documents" OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 28064)
-- Name: Documents_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Documents" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Documents_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 216 (class 1259 OID 28065)
-- Name: Passengers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Passengers" (
    "Id" bigint NOT NULL,
    "Name" character varying NOT NULL,
    "Surname" character varying NOT NULL,
    "Patronymic" character varying
);


ALTER TABLE public."Passengers" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 28070)
-- Name: Passengers_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Passengers" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Passengers_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 218 (class 1259 OID 28071)
-- Name: Tickets; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Tickets" (
    "OrderNumber" bigint NOT NULL,
    "OrderTime" timestamp without time zone NOT NULL,
    "DeparturePoint" character varying NOT NULL,
    "ArrivalPoint" character varying NOT NULL,
    "DepartureTime" timestamp without time zone NOT NULL,
    "ArrivalTime" timestamp without time zone NOT NULL,
    "Provider" character varying NOT NULL
);


ALTER TABLE public."Tickets" OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 28076)
-- Name: Tickets_Passengers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Tickets_Passengers" (
    "OrderNumber" bigint NOT NULL,
    "PassengerId" bigint NOT NULL
);


ALTER TABLE public."Tickets_Passengers" OWNER TO postgres;

--
-- TOC entry 3341 (class 0 OID 28059)
-- Dependencies: 214
-- Data for Name: Documents; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Documents" OVERRIDING SYSTEM VALUE VALUES (1, 'Военный билет', 'АЕ 4523753', 1);
INSERT INTO public."Documents" OVERRIDING SYSTEM VALUE VALUES (2, 'Паспорт', '2974 654286', 1);
INSERT INTO public."Documents" OVERRIDING SYSTEM VALUE VALUES (3, 'Паспорт', '7652 984572', 2);
INSERT INTO public."Documents" OVERRIDING SYSTEM VALUE VALUES (4, 'Паспорт', '9482 568632', 3);
INSERT INTO public."Documents" OVERRIDING SYSTEM VALUE VALUES (5, 'Временное удостоверение личности', '543', 4);
INSERT INTO public."Documents" OVERRIDING SYSTEM VALUE VALUES (6, 'Brittish Passport', '543874312', 4);
INSERT INTO public."Documents" OVERRIDING SYSTEM VALUE VALUES (7, 'Japan Passport', 'TG5423764', 5);
INSERT INTO public."Documents" OVERRIDING SYSTEM VALUE VALUES (8, 'Паспорт', '6542 654127', 6);
INSERT INTO public."Documents" OVERRIDING SYSTEM VALUE VALUES (9, 'Паспорт', '7683 765123', 7);
INSERT INTO public."Documents" OVERRIDING SYSTEM VALUE VALUES (10, 'Brittish Passport', '763465126', 8);
INSERT INTO public."Documents" OVERRIDING SYSTEM VALUE VALUES (11, 'Brittish Passport', '987326541', 9);
INSERT INTO public."Documents" OVERRIDING SYSTEM VALUE VALUES (12, 'French Passport', 'K6PL54312', 10);


--
-- TOC entry 3343 (class 0 OID 28065)
-- Dependencies: 216
-- Data for Name: Passengers; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Passengers" OVERRIDING SYSTEM VALUE VALUES (1, 'Ярослав', 'Мамашев', 'Авдеевич');
INSERT INTO public."Passengers" OVERRIDING SYSTEM VALUE VALUES (2, 'Кузьма', 'Кабанов', 'Лаврович');
INSERT INTO public."Passengers" OVERRIDING SYSTEM VALUE VALUES (3, 'Леонид', 'Бобров', 'Александрович');
INSERT INTO public."Passengers" OVERRIDING SYSTEM VALUE VALUES (4, 'Dixie', 'Russell', NULL);
INSERT INTO public."Passengers" OVERRIDING SYSTEM VALUE VALUES (5, 'Lindsey', 'Yu', NULL);
INSERT INTO public."Passengers" OVERRIDING SYSTEM VALUE VALUES (6, 'Ангелина', 'Ртищева', 'Игоревна');
INSERT INTO public."Passengers" OVERRIDING SYSTEM VALUE VALUES (7, 'Алла', 'Дубовчук', 'Богдановна');
INSERT INTO public."Passengers" OVERRIDING SYSTEM VALUE VALUES (8, 'June', 'Evans', NULL);
INSERT INTO public."Passengers" OVERRIDING SYSTEM VALUE VALUES (9, 'London', 'Barker', NULL);
INSERT INTO public."Passengers" OVERRIDING SYSTEM VALUE VALUES (10, 'Abby', 'Berg', NULL);


--
-- TOC entry 3345 (class 0 OID 28071)
-- Dependencies: 218
-- Data for Name: Tickets; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Tickets" VALUES (326987538523, '2023-08-05 19:05:34.458', 'Moscow', 'Dusseldorf', '2023-08-12 15:00:00', '2023-08-12 22:53:00', 'Air Serbia');
INSERT INTO public."Tickets" VALUES (7643523476, '2023-10-01 10:17:52.652', 'Penza', 'Moscow', '2023-10-03 05:00:00', '2023-10-03 06:20:00', 'S7 Airlines');
INSERT INTO public."Tickets" VALUES (8762354387, '2023-09-18 22:43:21.347', 'Vladivostok', 'Krasnoyarsk', '2023-09-22 12:30:00', '2023-09-22 16:39:00', 'Ural Airlines');
INSERT INTO public."Tickets" VALUES (6547769234, '2023-09-15 16:54:32.439', 'Orenburg', 'Sochi', '2023-09-18 22:15:00', '2023-09-19 01:25:00', 'Aeroflot');
INSERT INTO public."Tickets" VALUES (7653234687, '2023-07-09 17:43:25.883', 'Khabarovsk', 'Irkutsk', '2023-07-15 20:40:00', '2023-07-16 00:10:00', 'S7 Airlines');


--
-- TOC entry 3346 (class 0 OID 28076)
-- Dependencies: 219
-- Data for Name: Tickets_Passengers; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Tickets_Passengers" VALUES (7653234687, 1);
INSERT INTO public."Tickets_Passengers" VALUES (7653234687, 7);
INSERT INTO public."Tickets_Passengers" VALUES (7653234687, 6);
INSERT INTO public."Tickets_Passengers" VALUES (6547769234, 2);
INSERT INTO public."Tickets_Passengers" VALUES (8762354387, 3);
INSERT INTO public."Tickets_Passengers" VALUES (8762354387, 8);
INSERT INTO public."Tickets_Passengers" VALUES (7643523476, 2);
INSERT INTO public."Tickets_Passengers" VALUES (7643523476, 10);
INSERT INTO public."Tickets_Passengers" VALUES (326987538523, 4);
INSERT INTO public."Tickets_Passengers" VALUES (326987538523, 5);
INSERT INTO public."Tickets_Passengers" VALUES (326987538523, 9);


--
-- TOC entry 3353 (class 0 OID 0)
-- Dependencies: 215
-- Name: Documents_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Documents_Id_seq"', 12, true);


--
-- TOC entry 3354 (class 0 OID 0)
-- Dependencies: 217
-- Name: Passengers_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Passengers_Id_seq"', 10, true);


--
-- TOC entry 3187 (class 2606 OID 28080)
-- Name: Documents AK_Documents; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Documents"
    ADD CONSTRAINT "AK_Documents" UNIQUE ("DocumentType", "DocumentNumber");


--
-- TOC entry 3189 (class 2606 OID 28082)
-- Name: Documents PK_Documents; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Documents"
    ADD CONSTRAINT "PK_Documents" PRIMARY KEY ("Id");


--
-- TOC entry 3191 (class 2606 OID 28084)
-- Name: Passengers PK_Passengers; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Passengers"
    ADD CONSTRAINT "PK_Passengers" PRIMARY KEY ("Id");


--
-- TOC entry 3193 (class 2606 OID 28086)
-- Name: Tickets PK_Tickets; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Tickets"
    ADD CONSTRAINT "PK_Tickets" PRIMARY KEY ("OrderNumber");


--
-- TOC entry 3195 (class 2606 OID 28088)
-- Name: Tickets_Passengers PK_Tickets_Passengers; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Tickets_Passengers"
    ADD CONSTRAINT "PK_Tickets_Passengers" PRIMARY KEY ("OrderNumber", "PassengerId");


--
-- TOC entry 3196 (class 2606 OID 28089)
-- Name: Documents FK_Documents_Passengers_PassengerId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Documents"
    ADD CONSTRAINT "FK_Documents_Passengers_PassengerId" FOREIGN KEY ("PassengerId") REFERENCES public."Passengers"("Id") ON DELETE CASCADE NOT VALID;


--
-- TOC entry 3197 (class 2606 OID 28094)
-- Name: Tickets_Passengers FK_TicketsPassengers_Passengers_PassengerId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Tickets_Passengers"
    ADD CONSTRAINT "FK_TicketsPassengers_Passengers_PassengerId" FOREIGN KEY ("PassengerId") REFERENCES public."Passengers"("Id") ON DELETE CASCADE NOT VALID;


--
-- TOC entry 3198 (class 2606 OID 28099)
-- Name: Tickets_Passengers FK_TicketsPassengers_Tickets_OrderNumber; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Tickets_Passengers"
    ADD CONSTRAINT "FK_TicketsPassengers_Tickets_OrderNumber" FOREIGN KEY ("OrderNumber") REFERENCES public."Tickets"("OrderNumber") ON DELETE CASCADE NOT VALID;


-- Completed on 2023-09-02 03:03:05

--
-- PostgreSQL database dump complete
--

