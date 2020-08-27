## Example algorithm Supervised Learning 
# Load in memory the livrary with the SVM algorithm
library("e1071")

# Get the Iris dataset
datasetIris <- iris

# Change names of columns
names(datasetIris) <- c("Sepala.Tamanho", "Sepala.Largura", "Petala.Tamanho", "Petala.Largura", "Especies")

# Let's check out how the distribution of this dataset is
summary(datasetIris)


datasetIrisPart  <- datasetIris[,c(3,4,5)]
summary(datasetIrisPart)


# I need to show some of the Dataset for the algorithm to learn.
# Then I have to test it with the rest of the dataset.

# Cut the dataset randomly 
indexes = sample(1:nrow(datasetIrisPart), size=(0.3*nrow(datasetIrisPart)))

# I separate 70% of training and 30% test
dataset_treino = datasetIrisPart[-indexes,]
dataset_teste = datasetIrisPart[indexes,]

# Summary test dataset
summary(dataset_teste)

# Summary train dataset
summary(dataset_treino)

####
# Here I train my SVM model!
svm_model <- svm(Especies ~ ., data = dataset_treino)
####

# Here I train my SVM model with other parameters (uncomment to play)
#svm_model <- svm(Especies ~ ., data=dataset_treino, kernel="radial", cost=1, gamma=1)

#Plot the train results
plot(svm_model , dataset_treino)




# Taking only the columns with the sizes and widths of Petala
tamanhos_Larguras_teste = subset(dataset_teste, select = -Especies)

summary(tamanhos_Larguras_teste)

####
# Now, I'm going to get the Test Dataset, without the Labels of the "Especies" (Species)
svm_predicao <- predict(svm_model, newdata = tamanhos_Larguras_teste)
####


# Now, let's check out the successes of the prediction made up, passing only the labels Species
table(dataset_teste[,3], svm_predicao)


# Show test dataset again
summary(dataset_teste)

# Calculating Accuracy
sum(diag(table(dataset_teste[,3], svm_predicao))) / length(dataset_teste[,3])

# Show result with plot
plot(svm_model, dataset_teste)


