// Created 22.10.2015
// Modified by  24.12.2015 at 14:39


#if !ZEN_NOT_UNITY3D

namespace Zenject {
    #region References

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ModestTree;
    using UnityEngine;
    using Object = UnityEngine.Object;

    #endregion

    public class PrefabSingletonLazyCreator {
        private readonly DiContainer _container;
        private readonly PrefabSingletonProviderMap _owner;
        private readonly PrefabSingletonId _id;

        private int _referenceCount;
        private GameObject _rootObj;

        public PrefabSingletonLazyCreator(
            DiContainer container, PrefabSingletonProviderMap owner,
            PrefabSingletonId id) {
            _container = container;
            _owner = owner;
            _id = id;

            Assert.IsNotNull(id.Prefab);
        }

        public GameObject Prefab {
            get { return _id.Prefab; }
        }

        public GameObject RootObject {
            get { return _rootObj; }
        }

        public void IncRefCount() {
            _referenceCount += 1;
        }

        public void DecRefCount() {
            _referenceCount -= 1;

            if (_referenceCount <= 0) {
                _owner.RemoveCreator(_id);
            }
        }

        public IEnumerable<Type> GetAllComponentTypes() {
            return _id.Prefab.GetComponentsInChildren<Component>(true).Where(x => x != null).Select(x => x.GetType());
        }

        public bool ContainsComponent(Type type) {
            return !_id.Prefab.GetComponentsInChildren(type, true).IsEmpty();
        }

        public object GetComponent(Type componentType, InjectContext context) {
            if (_rootObj == null) {
                _rootObj = Object.Instantiate(_id.Prefab);

                // Default parent to comp root
                //_rootObj.transform.SetParent(_container.Resolve<CompositionRoot>().transform, false);
                _rootObj.transform.SetParent(_container.RootTransform, false);
                _rootObj.SetActive(true);

                _container.InjectGameObject(_rootObj, true, false, new object[0], context);
            }

            var component = _rootObj.GetComponentInChildren(componentType);

            if (component == null) {
                throw new ZenjectResolveException(
                    "Could not find component with type '{0}' in given singleton prefab".Fmt(componentType));
            }

            return component;
        }
    }
}

#endif