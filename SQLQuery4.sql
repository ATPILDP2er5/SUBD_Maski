SELECT Product.Title, Product.ArticleNumber, Product.MinCostForAgent, Product.Image, Material.Title AS SpisokMat
FROM     Product INNER JOIN
                  ProductMaterial ON Product.ID = ProductMaterial.ProductID INNER JOIN
                  Material ON ProductMaterial.MaterialID = Material.ID