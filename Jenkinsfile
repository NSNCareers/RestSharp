pipeline {
        agent any
         environment {
             registry = "dockerelvis/restsharpapi"
             registryCredential = 'dockerhub'
             dockerImagenotage = ''
                    }

             stages {
                 stage ('Restore Stage') {
                      steps {
                         sh'dotnet restore'
                        }
                    }
             stage ('Clean Stage') {
                     steps {
                         sh'dotnet clean'
                        }
                    }
              stage ('Build Stage') {
                     steps {
                        sh'dotnet build --configuration Release'
                        }
                    }
             stage ('Test Stage') {
                     steps {
                          sh'dotnet test'
                            }
                        }
            stage ('Pack Stage') {
                     steps {
                          sh'dotnet pack --no-build --output nupkgs'
                        }
                    }
              stage ('Build Image') {
                      steps {
                            script {
                               dockerImage = docker.build registry + ":$BUILD_NUMBER"
                               dockerImagenotage = docker.build registry
                          }
                        }
                                         
                    }
               stage ('Deploy Image') {
                     steps {
                          script{
                              withDockerRegistry(credentialsId: '575140d9-14b4-4d0e-8106-6a6509ff19b7', url: 'https://index.docker.io/v1/')
                                  
                                  {     
                              dockerImagenotage.push()
                              }
                          }

                        }
                    }
               stage ('Remove unused docker Image') {
                     steps {
                         script{
                              sh "docker rmi $registry:$BUILD_NUMBER"
                          }
                        }
                    }

                 }
            }
