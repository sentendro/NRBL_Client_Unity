using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class AUnit : MonoBehaviour {
    //유닛의 고유번호
    public string ID;
    //유닛의 현재 체력
    public int currentHealth;
    //유닛의 최대 체력
    public int maxHealth;
    //유닛의 공격력
    public int attack;
    //유닛의 비용
    public int cost;
    //유닛의 인구
    public int pop;
    //유닛의 위치
    public Vector2 tiledPosition;
    // TODO:플레이어 객체로 변환 필요
    //유닛의 소유자
    public int owner;
    //턴 종료 시 유닛의 행동
    public abstract void Behavior();
}
