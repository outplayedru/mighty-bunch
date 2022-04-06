using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

//public class Ammunition : MonoBehaviour
//{
    interface IAmmunition
    {
        public string Name { get; }//�������� ��������
        public bool IsDefense { get; }//���������� ������������ ��������� ������� ��� ����������
        public int Value { get; }//����������� ��������(��������) �������������� ����
        public int Range { get; }//����������� ��������� �������� ������

    }
    
    abstract class AmmunitionPattern : IAmmunition
    {
        protected string _name;
        protected bool _isDefense;
        protected int _lifetime;
        protected int _value;
        protected int _range;

        public int Lifetime //����������� ����������������� �������� ��������
        {
            get
            {
                return _lifetime;
            }
            set
            {
                _lifetime += value;
                //���������� ��������� ����� ���� �������� ����� ����
            }
        }

        public string Name => _name;//�������� ��������
        public bool IsDefense => _isDefense;//���������� ������������ ��������� ������� ��� ����������
        public int Value => _value;//����������� ��������(��������) �������������� ����
        public int Range => _range;//����������� ��������� �������� ������
    }

    class Hemlet : AmmunitionPattern
    {
        public Hemlet()
        {
            _name = "����";
            _isDefense = true;
            _lifetime = 2;
            _value = 1;
            _range = 0;
        }
    }

    class Shield : AmmunitionPattern
    {
        public Shield()
        {
            _name = "���";
            _isDefense = true;
            _lifetime = 1;
            _value = 2;
            _range = 0;
        }
    }

    class Peak : AmmunitionPattern
    {
        public Peak()
        {
            _name = "����";
            _isDefense = false;
            _lifetime = 1;
            _value = 0;
            _range = 2;
        }
    }

    class Horse : AmmunitionPattern
    {
        public Horse()
        {
            _name = "�������";
            _isDefense = false;
            _lifetime = 2;
            _value = 1;
            _range = 1;
        }
    }

//void Start()
//    {
        
//    }

    // Update is called once per frame
//    void Update()
//    {
        
 //   }
//}
