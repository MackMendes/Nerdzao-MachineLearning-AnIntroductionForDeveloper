## Example algorithm Supervised Learning 
# Load in memory the livrary with the Neural Network algorithm
library(nnet)

# Get the Iris dataset
datasetIris <- iris

# Change names of columns
names(datasetIris) <- c("Sepala.Tamanho", "Sepala.Largura", "Petala.Tamanho", "Petala.Largura", "Especies")

# Let's check out how the distribution of this dataset is
summary(datasetIris)


# I need to show some of the Dataset for the algorithm to learn.
# Then I have to test it with the rest of the dataset

xEntrada <- data.frame(datasetIris$Sepala.Tamanho, datasetIris$Sepala.Largura, datasetIris$Petala.Tamanho,
                       datasetIris$Petala.Largura)

xSaida <- data.frame(setosa = ifelse(datasetIris$Especies == "setosa",1,0), 
                     versicolor = ifelse(datasetIris$Especies == "versicolor",1,0), 
                     virginica = ifelse(datasetIris$Especies == "virginica",1,0))

summary(xEntrada)

summary(xSaida)

#################################
# Cut the dataset randomly
indexes = sample(1:nrow(datasetIris), size=(0.3*nrow(datasetIris)))

# I separate 70% of training and 30% test input
dataset_treino_Entrada = xEntrada[-indexes,]
dataset_teste_Entrada = xEntrada[indexes,]

# I separate 70% of training and 30% test output
dataset_treino_Saida = xSaida[-indexes,]
dataset_teste_Saida = xSaida[indexes,]


####
# I'll train my neural network
# Size = Hidden layer size;
# rang = Initial random weights in [-rang, rang];
# Decay = Parameter for the deterioration of weight;
# maxit = Maximum number of interactions until converge;
rna_model <- nnet(x = dataset_treino_Entrada, y = dataset_treino_Saida, size = 4, rang = 0.1,
                  decay = 5e-4, maxit = 1000)

####

library(NeuralNetTools)

# Show result with plot
plotnet(rna_model, alpha=0.6)

####
# Now, I'm going to get the Test Dataset, without the Labels of the Species
rna_predicao <- round(predict(rna_model, dataset_teste_Entrada))
####


Table1<-abs(rna_predicao - dataset_teste_Saida)


Error <- (sum(Table1)/2) / nrow(dataset_teste_Saida)

# Calculating Accuracy
1-Error





#Plot the results
#plot(dataset_treino_Entrada, rna_model$fitted.values)


