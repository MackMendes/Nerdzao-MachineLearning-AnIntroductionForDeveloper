## Example algorithm Unsupervised Learning 
# The kmeans livrary is of R framework, so it is not necessary to load it. 

# Get the Iris dataset
datasetIris <- iris

names(datasetIris) <- c("Sepala.Tamanho", "Sepala.Largura", "Petala.Tamanho", "Petala.Largura", "Especies")

# Let's check out how the distribution of this dataset is
summary(datasetIris)

# Taking only the columns with sizes and widths petal
tamanhos_Larguras = datasetIris[,-5]

# Run the k-means algorithm with the filtered dataset above (x) and ask to find 3 groups (centers).
resultado <- kmeans(x = tamanhos_Larguras, centers = 3)

# Show the result
resultado

# Joining the results with the names of the species 
table(datasetIris$Especies, resultado$cluster)

# Show the result with plot, taking into account the attributes of the petal
plot(tamanhos_Larguras[c("Sepala.Tamanho", "Sepala.Largura")], col=resultado$cluster)
points(resultado$centers[,c("Sepala.Tamanho", "Sepala.Largura")], col=1:3, pch="o", cex=3)

# ====
# Calculte indexes Jaccard and Rand

# Load the clusteval package
if(!require(clusteval)) install.packages("clusteval")
library("clusteval")

funcaoConverteResultado <- function(especie){
   sapply(especie, function(x) if(x == "setosa") 1 else if (x == "versicolor") 2 else 3)
}

resultadoEsperado <- funcaoConverteResultado(datasetIris$Especies[])

# Calculate Jaccard index
resultadoJaccard <- cluster_similarity(resultado$cluster, resultadoEsperado, similarity = "jaccard", method = "independence")
resultadoJaccard

# Calculate Rand index
resultRand <- cluster_similarity(resultado$cluster, resultadoEsperado, similarity = "rand", method = "independence")
resultRand
