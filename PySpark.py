import os
import sys

os.environ['PYSPARK_PYTHON'] = sys.executable
os.environ['PYSPARK_DRIVER_PYTHON'] = sys.executable

from pyspark.sql import SparkSession

spark=SparkSession.builder.appName('Proba').getOrCreate()

products = spark.createDataFrame([
    (1, 'Product 1'),
    (2, 'Product 2'),
    (3, 'Product 3'),
    (4, 'Product 4'),
    (5, 'Product 5'),
    (6, 'Product 6'),
    (7, 'Product 7'),
    (8, 'Product 8'),
    (9, 'Product 9'),
    (10, 'Product 10')],
    ['id', 'product_name'],
)

categories = spark.createDataFrame([
    (1, 'Category A'),
    (2, 'Category B'),
    (3, 'Category C'),
    (4, 'Category D'),
    (5, 'Category E'),
    (6, 'Category F'),
    (7, 'Category G'),
    (8, 'Category H'),
    (9, 'Category I'),
    (10, 'Category J')],
    ['id', 'category_name']
)

connection = spark.createDataFrame([
    (2, 3),
    (2, 2),
    (3, 3),
    (4, 1),
    (5, 2),
    (6, 3),
    (7, 4),
    (8, 5),
    (9, 6),
    (10, 7),
    (4, 8),
    (8, 9),
    (1, 5),
    (6, 4),
    (2, 2)],
    ['product_id', 'category_id']
)

product_with_categories = (products.join(connection, products.id == connection.product_id, how='left')
                           .join(categories, connection.category_id == categories.id, how='left')
                           .orderBy(products.id, 'category_name')
                           .select(['product_name', 'category_name']))

product_with_categories.show()