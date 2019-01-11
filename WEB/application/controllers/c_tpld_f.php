<?php
	 class C_tpld_f extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPLD_F.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPLD_F.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpld_fid' =>  $this->input->get_post('tpld_fid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
            );
            $tpld_f = $this->m_tpld_f->setRow($data);
            print json_encode($tpld_f);
    }
    function newRow() {
            log_message('debug', 'TPLD_F.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpld_fid' =>  $this->input->get_post('tpld_fid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'name' =>   $this->input->get_post('name', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpld_f= $this->m_tpld_f->newRow($instanceid,$data);
            $return = $tpld_f;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPLD_F.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpld_f = $this->m_tpld_f->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpld_f
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpld_f= $this->m_tpld_f->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpld_f= $this->m_tpld_f->getRows($sort);
                }
            }else{
              $tpld_f= $this->m_tpld_f->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpld_f
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPLD_F.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpld_f= $this->m_tpld_f->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpld_f
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'TPLD_F.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'name', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpld_f= $this->m_tpld_f->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpld_f
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'TPLD_F.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpld_fid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpld_f->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_tpld_f', 'm_tpld_f');
    }
}
?>