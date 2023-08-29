INSERT INTO Brand VALUES ('Modelo'), ('Minerva'), ('Erdinger'), ('Modern Times');
SELECT * FROM Brand;

INSERT INTO Beer VALUES ('Corona', 1);
SELECT * FROM Beer;

SELECT * FROM Beer BE
INNER JOIN Brand BR
ON BR.BrandId = BE.BrandId