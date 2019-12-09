oc new-project openshifttestapp
oc create serviceaccount devops
oc policy add-role-to-user admin system:serviceaccount:openshifttestapp:devops
oc serviceaccounts get-token devops