using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //힙 스택 개념 <-- 이새끼 걍 중요함
    //걍 가르쳐.
    
    //gpt왈 카데고리별 정리,
    //접근 제한자 순서별 정리가 있다 했지만
    //일단 접근 제한자 기준으로 정리
        
    //변수 띄어쓰기부분마다 대문자쓰기.
    //bool 변수는 앞에 동사로
    //private,protected는 소문자로 시작
    
    //얘넨 기믹용으로 만들어두긴했는데...음 그래그래
    public bool CanDoubleJump { get; set; } //이걸로 프로퍼티를 설명하자.
    public bool CanMove { get; set; }//프로퍼티는 대문자로 시작.
    
    //예시로다가 더블점프도 있고, 블럭 밟으면 사라지는 블럭, 중력 반전 - 심화 -> 힌트를 주고 
    //시네마신 추가로 따로 알려줘야됌 
    //타일맵도 다 알려줘야돼 -> 그리고 타일컴포도 다 알려줘야돼
    //별 만들기 까지해서 온트리거 -> 이벤트 함수 배우고
    //이제 어딘가에 닿아서 죽어서 탈락UI를 띄우십쇼(UI제공) <- 숙제1
    //기믹 하나를 만들어 오세요
    //블럭들이 플레이어 감지하고 컴포를가져오는거까지는 설명해줘야할듯 
    //예시 : 더블점프 -> 제일 쉬움 (기존 코드에 추가)
    //예시 : 밟으면 사라지는 블럭 -> 쉬움
    //예시 : 점프파워 증가 -> 살짝 심화(기존 코드를 건드려야함)
    //예시 : 중력 반전 -> 점프 방향, 중력값 -> 두가지만 반대로 건드리면됨 생각보다 쉬움
    //예시 : 로켓발사 -> 너? 개쩌는놈
    //보상 있음? 다 해오면 내가 3천원 자판기 쏜다
    
    //싱글톤같은거는 이런방법이 있으니까? 이런거 알고싶으면 개인적으로 따로물어보면 알려주겠다.
    //지금 당장은 기초적인거만 보자
    [SerializeField] private Transform groundCheckerTrm;
    [SerializeField] private LayerMask groundLayer;//레이어 마스크를 설명하려면 레이어를 우선 설명 해야함
    [SerializeField] private Vector2 groundCheckerSize;
    [SerializeField] private float jumpForce = 5f; // 직렬화한건 _ 달지 않기
    [SerializeField] private float moveSpeed = 5f; // 직렬화한건 _ 달지 않기
    
    private Rigidbody2D _rbCompo;
    private bool _isGrounded = false; //프라이빗 변수는 _ 달기

    private void Awake()
    {
        _rbCompo = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MoveInput();
    }
    private void FixedUpdate()
    {
        CheckGround();
        Jump();
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rbCompo.linearVelocityY = 0;
            AddForce(Vector2.up * jumpForce);
        }
    }

    private void AddForce(Vector2 force, ForceMode2D forceMode = ForceMode2D.Impulse)//여기서 매게변수의 기본값? 을 가르쳐주자
    {
        _rbCompo.AddForce(force, forceMode);
    }

    private void MoveInput()
    {
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            MovePlayer(-1f);
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            MovePlayer(1f);
        }
        else
        {
            MovePlayer(0f);
        }
    }
    
    public void MovePlayer(float x)
    {
        _rbCompo.linearVelocityX = x * moveSpeed;
    }

    private void CheckGround()
    {
        Collider2D hitCollider = Physics2D.OverlapBox(groundCheckerTrm.position,groundCheckerSize,
            0,groundLayer);

        if (hitCollider != null)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
        //이게(if문) 가장 기초적인 방법
        //이걸 한번 줄이면
        //_isGrounded = hitCollider != null;이것도 가능.
        //이걸 더 줄여서
        //_isGrounded = hitCollider;도 가능
        //순차적으로 다 알려주면 좋을듯.
    }


    #if UNITY_EDITOR//이것도 가르쳐줍시다.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(groundCheckerTrm == null) return;
        Gizmos.DrawWireCube(groundCheckerTrm.position,groundCheckerSize);
        Gizmos.color = Color.white;//그리고 나서 white로 초기화 해줘야함.
        //아마 내 기억상 다음에 그리는게 red로그려진다 했던거같은데 초기화 안해주면.
    }
    #endif
}
